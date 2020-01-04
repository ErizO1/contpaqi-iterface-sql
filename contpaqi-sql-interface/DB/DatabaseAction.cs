using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contpaqi_sql_interface.DB
{
    public class DatabaseAction
    {
        public DatabaseActionSystemName System { get; set; }
        public string Company { get; set; }
        public string DBName { get; set; }
        public string FilenameMDF { get; set; }
        public string FilenameLDF { get; set; }
        public string Action { get; set; }
    }
}
