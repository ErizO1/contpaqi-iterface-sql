using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace contpaqi_sql_interface.DB
{
    public abstract class SystemConnection
    {
        protected SystemConnection(CoreDB coreDB, string indexName)
        {
            this.coreDB = coreDB;
            this.indexName = indexName;

            string query = $@"
                SELECT
                    db.name AS DBName,
                    type_desc AS FileType,
                    Physical_Name AS Location
                FROM
                    sys.master_files mf
                INNER JOIN 
                    sys.databases db ON db.database_id = mf.database_id
                WHERE db.name = '{this.indexName}';
                ";
            SqlCommand command = this.coreDB.CreateCommand(query);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                this.IndexIsAttached = reader.Read();
            }

            this.SourceIndexExists = File.Exists($@"{Properties.Settings.Default.SourceDirectory}\{this.indexName}.mdf");
        }

        protected readonly CoreDB coreDB;
        public bool IndexIsAttached { get; protected set; } = false;
        public bool SourceIndexExists { get; protected set; } = false;

        protected string indexName = "";
        public List<PanelEntry> SelectedEntries { get; } = new List<PanelEntry>();
        public abstract PanelEntry[] GetDatabasesForAttach();
        public void AttachDatabase(string dbName, string filenameMdf, string filenameLdf, bool force = false)
        {
            string query = "";
            SqlCommand command = null;

            if (force)
            {
                query = $@"
                SELECT
                    db.name AS DBName,
                    type_desc AS FileType,
                    Physical_Name AS Location
                FROM
                    sys.master_files mf
                INNER JOIN 
                    sys.databases db ON db.database_id = mf.database_id
                WHERE db.name = '{dbName}';
                ";
                command = this.coreDB.CreateCommand(query);
                SqlDataReader reader = command.ExecuteReader();
                // If database is already attached
                if (reader.Read())
                {
                    reader.Close();
                    query = $"EXEC MASTER.dbo.sp_detach_db @dbname = N'{dbName}'";
                    command = this.coreDB.CreateCommand(query);
                    command.ExecuteNonQuery();
                }
                if (!reader.IsClosed) reader.Close();
            }

            query = $@"
                CREATE DATABASE [{dbName}]
                ON (FILENAME = '{this.coreDB.PhysicalLocation}\{filenameMdf}'),
                (FILENAME = '{this.coreDB.PhysicalLocation}\{filenameLdf}')
                FOR ATTACH;
            ";

            command = this.coreDB.CreateCommand(query);
            command.ExecuteNonQuery();
        }
        public void CopyDatasetFile(string filenameMdf, string filenameLdf, bool force = false)
        {
            this.SetPermissions($@"{this.coreDB.SourceDirectory}\{filenameMdf}");
            File.Copy($@"{this.coreDB.SourceDirectory}\{filenameMdf}", $@"{this.coreDB.PhysicalLocation}\{filenameMdf}", force);

            this.SetPermissions($@"{this.coreDB.SourceDirectory}\{filenameLdf}");
            File.Copy($@"{this.coreDB.SourceDirectory}\{filenameLdf}", $@"{this.coreDB.PhysicalLocation}\{filenameLdf}", force);
        }
        public void AttachIndex(bool force = false)
        {
            string query;
            string generalesMdf = $"{this.indexName}.mdf";
            string generalesLdf = $"{this.indexName}_log.ldf";

            if (force && this.IndexIsAttached)
            {
                query = $"EXEC MASTER.dbo.sp_detach_db @dbname = N'{this.indexName}'";
                using (SqlCommand detachCommand = this.coreDB.CreateCommand(query))
                {
                    detachCommand.ExecuteNonQuery();
                }
            }

            this.SetPermissions($@"{this.coreDB.SourceDirectory}\{generalesMdf}");
            File.Copy($@"{this.coreDB.SourceDirectory}\{generalesMdf}", $@"{this.coreDB.PhysicalLocation}\{generalesMdf}", force);


            this.SetPermissions($@"{this.coreDB.SourceDirectory}\{generalesLdf}");
            File.Copy($@"{this.coreDB.SourceDirectory}\{generalesLdf}", $@"{this.coreDB.PhysicalLocation}\{generalesLdf}", force);

            query = $@"
                CREATE DATABASE {this.indexName}
                ON (FILENAME = '{this.coreDB.PhysicalLocation}\{generalesMdf}'),
                (FILENAME = '{this.coreDB.PhysicalLocation}\{generalesLdf}')
                FOR ATTACH;
            ";

            SqlCommand command = this.coreDB.CreateCommand(query);
            command.ExecuteNonQuery();
            this.IndexIsAttached = true;
        }
        protected void SetPermissions(string fullPath)
        {
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
        }
        protected bool IsAttached(string dbName)
        {
            string query = $@"
                SELECT
                    db.name COLLATE Latin1_General_CI_AS FROM
                    master.sys.master_files mf
                INNER JOIN 
                    master.sys.databases db ON db.database_id = mf.database_id
                WHERE db.name = '{dbName}';
            ";
            SqlCommand command = coreDB.CreateCommand(query);
            SqlDataReader reader = command.ExecuteReader();

            bool result = reader.Read();

            reader.Close();

            return result;
        }
    }
}
