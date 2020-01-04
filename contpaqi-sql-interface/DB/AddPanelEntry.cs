using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contpaqi_sql_interface.DB
{
    public class AddPanelEntry
    {
        public string Nombre { get; set; }

        // GUIDs
        public string GUID { get; set; }
        public string GUIDContabilidad { get; set; }
        public string GUIDNominas { get; set; }
        public string GUIDComercial { get; set; }

        // DB Names
        public string DocumentContent { get; set; }
        public string DocumentMetadata { get; set; }
        public string OthersContent { get; set; }
        public string OthersMetadata { get; set; }

        // Filenames
        public string DocumentContentMDF { get; set; }
        public string DocumentContentLDF { get; set; }
        public string DocumentMetadataMDF { get; set; }
        public string DocumentMetadataLDF { get; set; }
        public string OthersContentMDF { get; set; }
        public string OthersContentLDF { get; set; }
        public string OthersMetadataMDF { get; set; }
        public string OthersMetadataLDF { get; set; }
    }
}
