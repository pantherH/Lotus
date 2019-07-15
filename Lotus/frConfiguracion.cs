using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Lotus
{
    public partial class frConfiguracion : Form
    {
        public frConfiguracion()
        {
            InitializeComponent();
        }


        

        private void EscribirArchivo()
        {
            //String ruta = Path.Combine(Application.StartupPath, @"Configuracion\Config.xml");
            String ruta = Program.ruta_configuracion;
            XElement xml = XElement.Load(ruta);
            xml.SetElementValue("Host", txtServidor.Text);
            xml.SetElementValue("Puerto", txtPuerto.Text);
            xml.SetElementValue("Usuario", Program.Encriptar(txtUsuario.Text));
            xml.SetElementValue("Pass", Program.Encriptar(txtPass.Text));
            xml.SetElementValue("Base", txtBase.Text);


            string host = xml.Element("Host").Value.ToString();
            string puerto = xml.Element("Puerto").Value.ToString();
            string usuario = Program.Desencriptar(xml.Element("Usuario").Value.ToString());
            string pass = Program.Desencriptar(xml.Element("Pass").Value.ToString());
            string base_datos = xml.Element("Base").Value.ToString();



            //Obtener el contacto con nombre Luis
            //var contactoLuis =
            //   (from c in xmlContactos.Descendants("Contacto")
            //    where c.Element("Nombre").Value.ToUpper() == "LUIS"
            //    select c).FirstOrDefault();

            //if (contactoLuis != null)
            //contactoLuis.SetElementValue("EMail", luis2@gmail.com);


            Conexion con = new Conexion(host, puerto, usuario, pass, base_datos);

            



                if (con.Conectar().State == ConnectionState.Open)
                {

                    string mensaje = "¿Deseas guardar esta configuración?";
                    string titulo = "Conexion Establecida";
                    MessageBoxButtons butones = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(mensaje, titulo, butones, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        xml.Save(ruta);
                        

                    }

                }
               
           
            

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            EscribirArchivo();
            

        }

        
    }
}
