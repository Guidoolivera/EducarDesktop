using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using EducarWeb.Clases;

namespace EducarWeb
{
    public partial class NotasAlumnoForm : Form
    {
        MySqlConnection conexion;
        long idUsuario;
        string nombre;
        string query = "SELECT n.calificacion, n.fecha, m.nombre AS nombre_materia, CONCAT(p.nombre, ' ', p.apellido) " +
            "AS nombre_alumno\r\nFROM nota n\r\nJOIN materia m ON n.materia_id = m.id\r\nJOIN persona p ON n.persona_id = p.id;\r\n";
        public NotasAlumnoForm(long idUsuario, MySqlConnection conexion)
        {
            InitializeComponent();
            
            this.idUsuario = idUsuario;
            this.conexion = conexion;
            obtenerNombre();
            using (conexion)
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
        private void obtenerNombre()
        {
            string consultaSql = "SELECT nombre, apellido FROM persona WHERE id = @id"; // Reemplaza con tu consulta SQL

            using (conexion)
            {
                conexion.Open();

                MySqlCommand command = new MySqlCommand(consultaSql, conexion);
                command.Parameters.AddWithValue("@id", idUsuario); // Reemplaza 1 con el ID de la persona que deseas obtener

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string nombre = reader["nombre"].ToString();
                        string apellido = reader["apellido"].ToString();

                        nombre = $"{nombre} {apellido}";
                        
                    }
                    else
                    {
                        Console.WriteLine("No se encontraron resultados para el ID especificado.");
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            datagridviewPrinter.PrintBoletin(dataGridView1,nombre);
        }
    }
}
