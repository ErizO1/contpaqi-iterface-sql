using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contpaqi_sql_interface.Components
{
    public partial class ActionItem : UserControl
    {
        private string _sistema = "";
        private string _empresa = "";
        private string _accion = "";
        private string _bd = "";
        private string _archivoMdf = "";
        private string _archivoLdf = "";

        public string Sistema
        {
            get
            {
                return this._sistema;
            }
            set
            {
                this.lbl_sistema.Text = value;
                this._sistema = value;
            }
        }
        public string Empresa {
            get {
                return this._empresa;
            }
            set {
                this.lbl_empresa.Text = value;
                this._empresa = value;
            }
        }
        public string Accion
        {
            get
            {
                return this._accion;
            }
            set
            {
                this.lbl_accion.Text = value;
                this._accion = value;
            }
        }
        public string BD
        {
            get
            {
                return this._bd;
            }
            set
            {
                this.lbl_bd.Text = value;
                this._bd = value;
            }
        }
        public string ArchivoMDF {
            get {
                return this._archivoMdf;
            }
            set {
                this.lbl_archivoMdf.Text = value;
                this._archivoMdf = value;
            }
        }
        public string ArchivoLDF
        {
            get {
                return this._archivoLdf;
            }
            set {
                this.lbl_archivoLdf.Text = value;
                this._archivoLdf = value;
            }
        }

        public ActionItem()
        {
            InitializeComponent();
        }
    }
}
