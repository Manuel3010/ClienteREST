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
        TipoRequisito registro;
        
        public FrmTipoRequisito()
        {
            InitializeComponent();
        }

        private void rbActivo_CheckedChanged(object sender, EventArgs e)
        {

        }


        public void buscarPorId(String id) {
            String urlId = url +"/"+ id;
            json = new WebClient().DownloadString(urlId);
            serializador = new JavaScriptSerializer();
            registro = serializador.Deserialize<TipoRequisito>(json);
            dtTipoRequisito.Rows.Clear();
            dtTipoRequisito.Rows.Add(registro.idTipoRequisito, registro.nombre, registro.activo, registro.observacion);
            //MessageBox.Show(registro.nombre);
            //dtTipoRequisito.Rows.Clear();

            /*dtTipoRequisito.Rows[0].Cells[0].Value = registro.idTipoRequisito;
            dtTipoRequisito.Rows[0].Cells[1].Value = registro.nombre;
            dtTipoRequisito.Rows[0].Cells[2].Value = registro.activo;
            dtTipoRequisito.Rows[0].Cells[3].Value = registro.observacion;*/



            //MessageBox.Show(urlId);




            //return null;
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
                    dtTipoRequisito.Rows[x - 1].Cells[2].Value = listaTipoRequisito[i].activo?"Activo":"Inactivo";
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

        private void button1_Click(object sender, EventArgs e)
        {
            buscarPorId("1");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFindId.Text == " ") {
                    MessageBox.Show("No ha introducido ningun valor de busqueda");
                }
                else
                {
                    String id = txtFindId.Text;
                    buscarPorId(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtFindId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
        {
            e.Handled = false;
        }
        else if (Char.IsControl(e.KeyChar))
        {
            e.Handled = false;
       }
       else if (Char.IsSeparator(e.KeyChar))
       {
           e.Handled = false;
       }
       else
       {
           e.Handled = true;
       }
        }
    }
}
