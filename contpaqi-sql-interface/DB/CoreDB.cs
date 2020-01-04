using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contpaqi_sql_interface.DB
{
    public class CoreDB
    {
        // Singleton Stuff

        private static CoreDB instance = null;
        private CoreDB() { }
        public static CoreDB Instance { 
            get
            {
                if (CoreDB.instance == null) instance = new CoreDB();
                return CoreDB.instance;
            }
        }

        // Scheduled actions
        public List<DatabaseAction> ScheduledActions { get; private set; } = new List<DatabaseAction>();

        // Event handlers
        private List<Action> onConnectingCallbacks = new List<Action>();
        public int AddOnConnectingEventHandler(Action action)
        {
            this.onConnectingCallbacks.Add(action);
            return this.onConnectingCallbacks.Count - 1;
        }
        private void RunOnConnectingCallbacks()
        {
            foreach (Action action in onConnectingCallbacks)
            {
                action?.Invoke();
            }
        }

        private List<Action> onConnectedCallbacks = new List<Action>();
        public int AddOnConnectedEventHandler(Action action)
        {
            this.onConnectedCallbacks.Add(action);
            return this.onConnectedCallbacks.Count - 1;
        }
        private void RunOnConnectedCallbacks()
        {
            foreach (Action action in onConnectedCallbacks)
            {
                action?.Invoke();
            }
        }

        private List<Action<int>> onProgressCallbacks = new List<Action<int>>();
        public int AddOnProgressEventHandler(Action<int> action)
        {
            this.onProgressCallbacks.Add(action);
            return this.onProgressCallbacks.Count - 1;
        }

        public void ClearOnProgressEventHandlers()
        {
            this.onProgressCallbacks.Clear();
        }

        private void RunOnProgressCallbacks(int step)
        {
            foreach (Action<int> action in onProgressCallbacks)
            {
                action?.Invoke(step);
            }
        }

        // Connection Config
        public string Host { get; set; } = "";
        public string User { get; set; } = "";
        public string Pass { get; set; } = "";
        public string Database { get; set; } = "";
        public string SourceDirectory { get; set; } = "";

        // Status
        public bool IsConnected { get; private set; } = false;

        public string PhysicalLocation { get; private set; } = null;

        public string Version { get; private set; } = null;

        private SqlConnection connection = null;

        // SystemConnections
        public ContabilidadConnection contabilidadConnection { get; private set; } = null;
        public NominasConnection nominasConnection { get; private set; } = null;
        public ComercialConnection comercialConnection { get; private set; } = null;
        public AddConnection addConnection { get; private set; } = null;

        public SqlCommand CreateCommand(string query)
        {
            return new SqlCommand(query, this.connection);
        }

        public void TestConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = this.Host;
            builder.UserID = this.User;
            builder.Password = this.Pass;
            builder.InitialCatalog = this.Database;

            var connection = new SqlConnection(builder.ConnectionString);

            connection.Open();
            connection.Close();
        }

        public void Connect()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = this.Host;
            builder.UserID = this.User;
            builder.Password = this.Pass;
            builder.InitialCatalog = this.Database;

            this.RunOnConnectingCallbacks();

            this.connection = new SqlConnection(builder.ConnectionString);
            this.connection.Open();
            this.IsConnected = true;

            this.contabilidadConnection = new ContabilidadConnection(this);
            this.nominasConnection = new NominasConnection(this);
            this.comercialConnection = new ComercialConnection(this);
            this.addConnection = new AddConnection(this);

            // Get Version
            string versionQuery = "select @@version";
            var cmd = new SqlCommand(versionQuery, connection);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                this.Version = reader.GetString(0);
            }

            // Get Physical Path
            string physicalNameQuery = "SELECT physical_name FROM sys.database_files";
            cmd = new SqlCommand(physicalNameQuery, connection);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                var physicalName = reader.GetString(0);

                this.PhysicalLocation = physicalName.Substring(0, physicalName.LastIndexOf("\\"));
            }


            this.RunOnConnectedCallbacks();
        }

        public void Disconnect()
        {
            connection?.Close();
            this.IsConnected = false;
        }
    
        public void ApplyChanges()
        {
            Task.Run(() =>
            {
                SystemConnection connection;

                for (int i = 0; i < this.ScheduledActions.Count; i++)
                {
                    var action = this.ScheduledActions[i];
                    RunOnProgressCallbacks(i);
                    switch (action.System)
                    {
                        case DatabaseActionSystemName.Contabilidad:
                            connection = this.contabilidadConnection;
                            break;
                        case DatabaseActionSystemName.Nominas:
                            connection = this.nominasConnection;
                            break;
                        case DatabaseActionSystemName.Comercial:
                            connection = this.comercialConnection;
                            break;
                        case DatabaseActionSystemName.ADD:
                            connection = this.addConnection;
                            break;
                        default:
                            continue;
                    }

                    switch (action.Action)
                    {
                        case "Copiar":
                            connection.CopyDatasetFile(action.FilenameMDF, action.FilenameLDF, true);
                            break;
                        case "Adjuntar":
                            connection.AttachDatabase(action.DBName, action.FilenameMDF, action.FilenameLDF, true);
                            break;
                        default:
                            continue;
                    }
                }
                RunOnProgressCallbacks(this.ScheduledActions.Count);
            });
        }
    }
}
