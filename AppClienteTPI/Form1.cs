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
            String json = new WebClient().DownloadString("http://localhost:8080/CasosAcadAppMvn-web/webresources/tipoRequisito/1"); //new WebClient().DownloadString();
       
         JavaScriptSerializer ser= new JavaScriptSerializer();
       // UsuarioEjemplo ueUsuario =ser.Deserialize<UsuarioEjemplo>(json);
         TipoRequisito ueUsuario = ser.Deserialize<TipoRequisito>(json);
         textBox1.Text = ueUsuario.idTipoRequisito.ToString();
         textBox2.Text = ueUsuario.nombre.ToString();

        }  





        //para primer commit
    }
}
