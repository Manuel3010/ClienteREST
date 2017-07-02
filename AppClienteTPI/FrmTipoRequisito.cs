using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Net;

namespace AppClienteTPI
{
    public partial class FrmTipoRequisito : Form
    {
        String url = "http://localhost:8080/CasosAcadAppMvn-web/webresources/tipoRequisito";
        String json;
        JavaScriptSerializer serializador;
        List<TipoRequisito> listaTipoRequisito;
        
        public FrmTipoRequisito()
        {
            InitializeComponent();
        }

        private void rbActivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void cargarTiposRequisito() {
            try
            {
                json = new WebClient().DownloadString(url);
                serializador = new JavaScriptSerializer();
                listaTipoRequisito = serializador.Deserialize<List<TipoRequisito>>(json);
                int tamanio = listaTipoRequisito.Count;
                this.dtTipoRequisito.Rows.Clear();
                for (int i = 0; i < listaTipoRequisito.Count; i++) { 
                    
                    dtTipoRequisito.Rows.Add();
                    int x= dtTipoRequisito.Rows.Count;

                    dtTipoRequisito.Rows[x - 1].Cells[0].Value = listaTipoRequisito[i].idTipoRequisito;
                    dtTipoRequisito.Rows[x - 1].Cells[1].Value = listaTipoRequisito[i].nombre;
                    dtTipoRequisito.Rows[x - 1].Cells[2].Value = listaTipoRequisito[i].activo;
                    dtTipoRequisito.Rows[x - 1].Cells[3].Value = listaTipoRequisito[i].observacion;
                }        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmTipoRequisito_Load(object sender, EventArgs e)
        {
            cargarTiposRequisito();
        }
    }
}
