using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EducarWeb
{
    public partial class CrearMateriaForm : Form
    {
        MySqlConnection conexion;
        public CrearMateriaForm(MySqlConnection conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
        }

        private void btn_Crear_Click(object sender, EventArgs e)
        {
            string nombreMateria = tb_NombreMateria.Text;

            // Realizar la inserción en la tabla `materia` de la base de datos
            string queryInsercion = "INSERT INTO materia (nombre) VALUES (@nombreMateria)";

            // No uses using(conexion) aquí para mantener la conexión abierta

            using (MySqlCommand cmd = new MySqlCommand(queryInsercion, conexion))
            {
                // Agregar parámetros para la consulta
                cmd.Parameters.AddWithValue("@nombreMateria", nombreMateria);

                // Ejecutar la consulta SQL para insertar la nueva materia en la base de datos
                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Materia creada correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al crear la materia.");
                }
            }
        }
    }

}
