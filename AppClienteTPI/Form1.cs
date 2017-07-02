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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
              /*  String json = new WebClient().DownloadString("http://localhost:8080/CasosAcadAppMvn-web/webresources/tipoRequisito/1"); //new WebClient().DownloadString();

                JavaScriptSerializer ser = new JavaScriptSerializer();
                // UsuarioEjemplo ueUsuario =ser.Deserialize<UsuarioEjemplo>(json);
                TipoRequisito ueUsuario = ser.Deserialize<TipoRequisito>(json);
                textBox1.Text = ueUsuario.idTipoRequisito.ToString();
                textBox2.Text = ueUsuario.nombre.ToString();*/
                JavaScriptSerializer ser = new JavaScriptSerializer();
                String json = new WebClient().DownloadString("http://localhost:8080/CasosAcadAppMvn-web/webresources/tipoRequisito");
               List<TipoRequisito> listaTipoRequisito = ser.Deserialize<List<TipoRequisito>>(json);
                int tamanio = listaTipoRequisito.Count;
                this.dtTipoRequisito.Rows.Clear();
                //MessageBox.Show("Prueba:" + tamanio);*/
                //json = new WebClient().DownloadString(url);
                //listaTipoRequisito = serializador.Deserialize<List<TipoRequisito>>(json);
                //int tamanio = listaTipoRequisito.Count;

                for (int i = 0; i <listaTipoRequisito.Count; i++)
                {

                    dtTipoRequisito.Rows.Add();
                    int x = dtTipoRequisito.Rows.Count;

                    dtTipoRequisito.Rows[x-1].Cells[0].Value = listaTipoRequisito[i].idTipoRequisito;
                    dtTipoRequisito.Rows[x-1].Cells[1].Value = listaTipoRequisito[i].nombre;
                    dtTipoRequisito.Rows[x-1].Cells[2].Value = listaTipoRequisito[i].activo;
                    dtTipoRequisito.Rows[x-1].Cells[3].Value = listaTipoRequisito[i].observacion;
                    //dtTipoRequisito.Columns["id"].


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  





        //para primer commit
    }
}
