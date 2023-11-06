using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EducarWeb.Clases
{
    internal static class CuotaUpdater
    {
        //private readonly MySqlConnection conexion;
        public static void Update(MySqlConnection conexion)
        {

            using (conexion)
            {
                //conexion.Open();

                using (MySqlCommand command = new MySqlCommand("ActualizarMontoCuota", conexion))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Monto de cuotas actualizadas");
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al actualizar monto de cuotas");
                    }
                }
            }
        }
        
    }
}
