using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EducarWeb.Clases
{
    internal class Conexion
    {
        MySqlConnection conex = new MySqlConnection();
        static string servidor = "b4rvajc57svembdlstfn-mysql.services.clever-cloud.com";
        static string bd = "b4rvajc57svembdlstfn";
        static string user = "u2jtqd59omfyrxxf";
        static string password = "IFQEz4NITM6m2Zc8gHNi";
        static string puerto = "3306";

        string cadenaConexion = "Server=" + servidor + ";" + "Port=" + puerto + ";" + "User Id=" + user + ";" + "Password=" + password + ";" + "Database=" + bd + ";";

        public MySqlConnection establecerConexion()
        {
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                //MessageBox.Show("Conexión realizada correctamente.");
            }
            catch (MySqlException ex) {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
            return conex;
        }

    }
}
