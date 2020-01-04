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
    public class ComercialConnection : SystemConnection
    {
        public ComercialConnection(CoreDB coreDB) : base(coreDB, "CompacWAdmin") { }

        public override PanelEntry[] GetDatabasesForAttach()
        {
            string query = $@"
                SELECT * FROM (
	                SELECT CNOMBREEMPRESA as NombreEmpresa, right(CRUTADATOS, charindex('\', reverse(CRUTADATOS) + '\') - 1) AS RutaEmpresa from {indexName}..Empresas
                ) AS EMPRESAS WHERE RutaEmpresa NOT IN (
                    SELECT
                        db.name COLLATE Latin1_General_CI_AS FROM
                        master.sys.master_files mf
                    INNER JOIN 
                        master.sys.databases db ON db.database_id = mf.database_id    
                )
                ";
            SqlCommand command = this.coreDB.CreateCommand(query);
            List<PanelEntry> dbs = new List<PanelEntry>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    PanelEntry pe = new PanelEntry
                    {
                        Empresa = reader.GetString(0),
                        Nombre = reader.GetString(1),
                        ArchivoMDF = $"{reader.GetString(1)}.mdf",
                        ArchivoLDF = $"{reader.GetString(1)}_log.ldf",
                    };
                    if (File.Exists($@"{this.coreDB.SourceDirectory}\{pe.Nombre}.mdf"))
                    {
                        dbs.Add(pe);
                    }
                }
            }

            return dbs.ToArray();
        }
    }
}
