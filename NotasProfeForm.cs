using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EducarWeb
{
    public partial class NotasProfeForm : Form
    {
        MySqlConnection conexion;
        long idUsuario;
        string query = "SELECT n.calificacion, n.fecha, m.nombre AS nombre_materia, CONCAT(p.nombre, ' ', p.apellido) " +
            "AS nombre_alumno\r\nFROM nota n\r\nJOIN materia m ON n.materia_id = m.id\r\nJOIN persona p ON n.persona_id = p.id;\r\n";
        public NotasProfeForm(long idUsuario, MySqlConnection conexion)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.conexion = conexion;

        }
        public void actualizarDataGridView()
        {
            using (conexion)
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
    }
}
