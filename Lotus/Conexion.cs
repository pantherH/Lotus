using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotus
{
    class Conexion
    {
        string host = "";
        string puerto = "";
        string usuario = "";
        string pass="";
        string baseD = "";

        public Conexion(string host, string puerto, string usuario, string pass, string baseD)
        {
            this.host = host;
            this.puerto = puerto;
            this.usuario = usuario;
            this.pass = pass;
            this.baseD = baseD;

        }


        public SqlConnection Conectar()
        {

            string provider = "System.Data.SqlClient";
            string cadenaConexion = "Data Source=" + host + "," + puerto
                 + ";Initial Catalog=" + baseD
                 + ";User ID=" + usuario
                 + ";Password=" + pass;
            //cadenaConexion+=" providerName = 'System.Data.SqlClient'";
            SqlConnection con = new SqlConnection(cadenaConexion);

            try
            {


                

                if (con.State == ConnectionState.Open)
                {

                    con.Close();

                }
                else
                {

                    con.Open();

                }
            }catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
                
                
                MessageBox.Show(ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }    

            return con;
        }



        public SqlConnection Conecta()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sql"].ConnectionString);

            if (con.State == ConnectionState.Open)
            {

                con.Close();

            }
            else
            {

                con.Open();

            }

            return con;

        }


    }
}
