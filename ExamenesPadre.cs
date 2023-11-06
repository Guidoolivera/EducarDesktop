using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EducarWeb.Clases;
using MySql.Data.MySqlClient;

namespace EducarWeb
{
    public partial class ExamenesPadre : Form
    {
        MySqlConnection conexion;
        long userId;
        string rol;
        public ExamenesPadre(MySqlConnection conexion, long userId, string rol)
        {
            InitializeComponent();

            this.rol = rol;
            this.conexion = conexion;
            this.userId = userId;
            if (rol == "Padre")
            {
                ActualizarDataGrid();
            }
            else
            {
                ActualizarDataGrid2();
            }
            
        }

        private void ActualizarDataGrid()
        {
            string query = "SELECT Hijo.nombre AS Nombre_del_hijo, Materia.nombre AS Nombre_de_la_materia, phm.Trimestre1, phm.Trimestre2, phm.Trimestre3 " +
               "FROM persona AS Padre " +
               "INNER JOIN persona_has_persona AS php ON Padre.id = php.padre_id " +
               "INNER JOIN persona AS Hijo ON php.hijo_id = Hijo.id " +
               "INNER JOIN persona_has_materia AS phm ON Hijo.id = phm.persona_id " +
               "INNER JOIN materia AS Materia ON phm.materia_id = Materia.id " +
               "WHERE Padre.id = @userId";

            using (conexion)
            {
                conexion.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    // Reemplaza 'ID_DEL_PADRE' con el valor del ID deseado
                    cmd.Parameters.AddWithValue("@userId", userId);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asigna el DataTable como fuente de datos del DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }
        private void ActualizarDataGrid2()
        {
            string query = "SELECT Hijo.nombre AS Nombre_del_hijo, Materia.nombre AS Nombre_de_la_materia, phm.Trimestre1, phm.Trimestre2, phm.Trimestre3 " +
                            "FROM persona AS Hijo " +
                            "INNER JOIN persona_has_materia AS phm ON Hijo.id = phm.persona_id " +
                            "INNER JOIN materia AS Materia ON phm.materia_id = Materia.id " +
                            "WHERE Hijo.id = @userId";

            using (conexion)
            {
                conexion.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    
                    cmd.Parameters.AddWithValue("@userId", userId);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asigna el DataTable como fuente de datos del DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }
        private string ObtenerNombreHijo(long userId)
        {
            string nombreYapellidoHijo = string.Empty;
            string query = "SELECT Hijo.nombre, Hijo.apellido " +
               "FROM persona AS Hijo " +
               "INNER JOIN persona_has_persona AS php ON Hijo.id = php.hijo_id " +
               "WHERE php.padre_id = @userId";

            using (conexion)
            {
                conexion.Open();
                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    // Agregar el parámetro para el ID del padre
                    command.Parameters.AddWithValue("@userId", userId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nombre = reader["nombre"].ToString();
                            string apellido = reader["apellido"].ToString();
                            nombreYapellidoHijo = nombre + " " + apellido;
                        }
                        return nombreYapellidoHijo;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(rol=="Padre")
            {
                datagridviewPrinter.PrintBoletin(dataGridView1, ObtenerNombreHijo(userId));
            }
            else
            {
                datagridviewPrinter.PrintBoletin(dataGridView1, ObtenerNombreAlumno(userId));
            }
            
        }
        private string ObtenerNombreAlumno(long userId)
        {
            string nombreYapellidoHijo = string.Empty;
            string query = "SELECT nombre, apellido FROM proyecto.persona WHERE id = 9;";

            using (conexion)
            {
                conexion.Open();
                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    // Agregar el parámetro para el ID del padre
                    command.Parameters.AddWithValue("@userId", userId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nombre = reader["nombre"].ToString();
                            string apellido = reader["apellido"].ToString();
                            nombreYapellidoHijo = nombre + " " + apellido;
                        }
                        return nombreYapellidoHijo;
                    }
                }
            }
        }
    }
}
