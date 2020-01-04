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
    public class AddConnection : SystemConnection
    {
        public AddConnection(CoreDB coreDB) : base(coreDB, "DB_Directory") { }

        public new List<AddPanelEntry> SelectedEntries = new List<AddPanelEntry>();

        public AddPanelEntry[] GetAddDatabasesForAttach()
        {
            if (!this.IndexIsAttached) return new AddPanelEntry[] { };

            List<AddPanelEntry> entries = new List<AddPanelEntry>();
            string query;
            SqlCommand command;
            SqlDataReader result;

            // Buscamos en Contabilidad
            #region Contabilidad
            if (this.coreDB.contabilidadConnection.IndexIsAttached)
            {
                query = @"
                select AliasBDD from GeneralesSQL..ListaEmpresas WHERE AliasBDD IN (
                    SELECT
                        db.name COLLATE Latin1_General_CI_AS FROM
                        master.sys.master_files mf
                    INNER JOIN 
                        master.sys.databases db ON db.database_id = mf.database_id);
                ";
                command = coreDB.CreateCommand(query);

                List<string> dbContabilidad = new List<string>();

                using (SqlDataReader dbReader = command.ExecuteReader())
                {
                    while (dbReader.Read())
                    {
                        dbContabilidad.Add(dbReader.GetString(0));
                    }
                }

                foreach (string db in dbContabilidad)
                {
                    // Check if the database is actually from contabilidad
                    query = $"SELECT name FROM {db}.sys.Tables WHERE name = 'Parametros'";
                    command = coreDB.CreateCommand(query);
                    var tableReader = command.ExecuteReader();
                    if (!tableReader.Read())
                    {
                        tableReader.Close();
                        continue;
                    }
                    tableReader.Close();

                    // Check if GUID Columns exists
                    query = $"SELECT * FROM {db}..Parametros WHERE 1 = 2";
                    command = coreDB.CreateCommand(query);
                    var columnReader = command.ExecuteReader();

                    bool guidFound = false;
                    for (int i = 0; i < columnReader.FieldCount; i++)
                    {
                        if (columnReader.GetName(i) == "GuidDSL")
                        {
                            guidFound = true;
                            break;
                        }
                    }
                    columnReader.Close();
                    if (!guidFound) continue;

                    query = $@"
                        select 
	                        Parametros.GuidDSL,
	                        Parametros.GuidEmpresa,
	                        db_add.NombreEmpresa,
	                        db_add.DB_DocumentsContent,
	                        db_add.DB_DocumentsMetadata,
	                        db_add.DB_OthersContent,
	                        db_add.DB_OthersMetadata
                        from {db}..Parametros as Parametros
                        inner join DB_Directory..DatabaseDirectory as db_add
	                        on UPPER(Parametros.GuidDSL) = UPPER(CAST(db_add.GuidCompany as varchar(40)));
                    ";
                    command = coreDB.CreateCommand(query);

                    result = command.ExecuteReader();
                    if (result.Read())
                    {
                        this.AppendToEntry(entries, new AddPanelEntry
                        {
                            GUID = result.GetString(0),
                            GUIDContabilidad = result.GetString(1),
                            Nombre = result.GetString(2),
                            DocumentContent = result.GetString(3),
                            DocumentMetadata = result.GetString(4),
                            OthersContent = result.GetString(5),
                            OthersMetadata = result.GetString(6),
                        });
                    }
                    result.Close();
                }
            }
            #endregion

            // Buscamos en Nóminas
            #region Nominas
            if (this.coreDB.nominasConnection.IndexIsAttached)
            {
                query = @"
                    select
	                    generales.GUIDDSL,
	                    generales.GUIDEmpresa,
	                    db_add.NombreEmpresa,
	                    db_add.DB_DocumentsContent,
	                    db_add.DB_DocumentsMetadata,
	                    db_add.DB_OthersContent,
	                    db_add.DB_OthersMetadata
                    from nomGenerales..NOM10000 as generales
                    inner join DB_Directory..DatabaseDirectory as db_add
	                    on UPPER(generales.GUIDDSL) = UPPER(CAST(db_add.GuidCompany as varchar(40)))
                    WHERE generales.RutaEmpresa IN (
	                    SELECT
		                    db.name AS DBName
	                    FROM
		                    sys.master_files mf
	                    INNER JOIN 
		                    sys.databases db ON db.database_id = mf.database_id
                    );
                ";

                command = coreDB.CreateCommand(query);

                result = command.ExecuteReader();
                while (result.Read())
                {
                    this.AppendToEntry(entries, new AddPanelEntry
                    {
                        GUID = result.GetString(0),
                        GUIDNominas = result.GetString(1),
                        Nombre = result.GetString(2),
                        DocumentContent = result.GetString(3),
                        DocumentMetadata = result.GetString(4),
                        OthersContent = result.GetString(5),
                        OthersMetadata = result.GetString(6),

                    });
                }
                result.Close();
            }
            #endregion

            // Buscamos en Comercial
            #region Comercial
            if (this.coreDB.comercialConnection.IndexIsAttached)
            {

                query = @"
                SELECT * FROM (
	                SELECT right(CRUTADATOS, charindex('\', reverse(CRUTADATOS) + '\') - 1) AS RutaEmpresa from CompacWAdmin..Empresas
                ) AS EMPRESAS WHERE RutaEmpresa IN (
                    SELECT
                        db.name COLLATE Latin1_General_CI_AS FROM
                        master.sys.master_files mf
                    INNER JOIN 
                        master.sys.databases db ON db.database_id = mf.database_id    
                )
            ";
                command = coreDB.CreateCommand(query);

                List<string> dbComercial = new List<string>();

                using (SqlDataReader dbReader = command.ExecuteReader())
                {
                    while (dbReader.Read())
                    {
                        dbComercial.Add(dbReader.GetString(0));
                    }
                }

                foreach (string db in dbComercial)
                {
                    query = $@"
                    SELECT
	                    generales.CGUIDDSL,
	                    generales.CGUIDEMPRESA,
	                    db_add.NombreEmpresa,
	                    db_add.DB_DocumentsContent,
	                    db_add.DB_DocumentsMetadata,
	                    db_add.DB_OthersContent,
	                    db_add.DB_OthersMetadata
                    FROM
	                    {db}..admParametros AS generales
                    inner join DB_Directory..DatabaseDirectory as db_add
	                    on UPPER(generales.CGUIDDSL) = UPPER(CAST(db_add.GuidCompany as varchar(40)));
                ";
                    command = coreDB.CreateCommand(query);

                    result = command.ExecuteReader();
                    if (result.Read())
                    {
                        this.AppendToEntry(entries, new AddPanelEntry
                        {
                            GUID = result.GetString(0),
                            GUIDComercial = result.GetString(1),
                            Nombre = result.GetString(2),
                            DocumentContent = result.GetString(3),
                            DocumentMetadata = result.GetString(4),
                            OthersContent = result.GetString(5),
                            OthersMetadata = result.GetString(6),

                        });
                    }
                    result.Close();
                }
            }
            #endregion

            // Devolvemos el array
            return entries.ToArray();
        }

        private void AppendToEntry(List<AddPanelEntry> entries, AddPanelEntry newEntry)
        {
            var foundEntry = entries.Find(e => e.GUID == newEntry.GUID);
            if (foundEntry != null)
            {
                foundEntry.GUIDContabilidad = newEntry.GUIDContabilidad ?? foundEntry.GUIDContabilidad;
                foundEntry.GUIDNominas = newEntry.GUIDNominas ?? foundEntry.GUIDNominas;
                foundEntry.GUIDComercial = newEntry.GUIDComercial ?? foundEntry.GUIDComercial;
            } else
            {
                newEntry.DocumentContentLDF = this.ResolveFileName(newEntry.DocumentContent);
                newEntry.DocumentContentMDF = $@"{newEntry.DocumentContent}.mdf";
                newEntry.DocumentMetadataLDF = this.ResolveFileName(newEntry.DocumentMetadata);
                newEntry.DocumentMetadataMDF = $@"{newEntry.DocumentMetadata}.mdf";
                newEntry.OthersContentLDF = this.ResolveFileName(newEntry.OthersContent);
                newEntry.OthersContentMDF = $@"{newEntry.OthersContent}.mdf";
                newEntry.OthersMetadataLDF = this.ResolveFileName(newEntry.OthersMetadata);
                newEntry.OthersMetadataMDF = $@"{newEntry.OthersMetadata}.mdf";
                entries.Add(newEntry);
            }
        }

        private string ResolveFileName(string databaseName)
        {
            string[] names = new string[]
            {
                $"{databaseName}.ldf",
                $"{databaseName}_log.ldf",
                $"mastlog.ldf{databaseName}.ldf"
            };

            foreach (string name in names)
            {
                if (File.Exists($@"{this.coreDB.SourceDirectory}\{name}"))
                    return name;
            }

            return "";
        }

        public override PanelEntry[] GetDatabasesForAttach()
        {
            return new PanelEntry[0];
        }
    }
}
