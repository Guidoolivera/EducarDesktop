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
            actualizarDataGridView();
            CargarMateriasParaProfesor(idUsuario);
        }
        public void actualizarDataGridView()
        {
            using (conexion)
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                CargarMateriasParaProfesor(idUsuario);
            }
        }
        private void CargarMateriasParaProfesor(long idUsuario)
        {
            comboBox1.Items.Clear(); // Limpia cualquier elemento previo en el ComboBox

            string consulta = "SELECT nombre FROM materia WHERE profesor_id = @idUsuario";

            using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
            {
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                if (conexion.State == ConnectionState.Closed)
                    conexion.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombreMateria = reader["nombre"].ToString();
                        comboBox1.Items.Add(nombreMateria);
                    }
                }
            }
        }
        private void CargarAlumnosDeMateria(long materiaId)
        {
            comboBox2.Items.Clear(); // Limpia cualquier elemento previo en el ComboBox

            string consulta = "SELECT p.nombre, p.apellido " +
                             "FROM persona p " +
                             "INNER JOIN persona_has_materia pm ON p.id = pm.persona_id " +
                             "WHERE pm.materia_id = @materiaId";

            using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
            {
                cmd.Parameters.AddWithValue("@materiaId", materiaId);

                if (conexion.State == ConnectionState.Closed)
                    conexion.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombreAlumno = reader["nombre"].ToString();
                        string apellidoAlumno = reader["apellido"].ToString();
                        string nombreCompleto = $"{nombreAlumno} {apellidoAlumno}";
                        comboBox2.Items.Add(nombreCompleto);
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear(); // Limpia cualquier elemento previo en el ComboBox2

            if (comboBox1.SelectedItem != null)
            {
                string materiaSeleccionada = comboBox1.SelectedItem.ToString();

                string consulta = "SELECT id FROM materia WHERE nombre = @nombreMateria";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombreMateria", materiaSeleccionada);

                    if (conexion.State == ConnectionState.Closed)
                        conexion.Open();

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        long materiaId = Convert.ToInt64(result);
                        CargarAlumnosDeMateria(materiaId);
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox2.Items.Clear(); // Limpia cualquier elemento previo en el ComboBox2

            if (comboBox1.SelectedItem != null)
            {
                string materiaSeleccionada = comboBox1.SelectedItem.ToString();

                string consulta = "SELECT id FROM materia WHERE nombre = @nombreMateria";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombreMateria", materiaSeleccionada);

                    if (conexion.State == ConnectionState.Closed)
                        conexion.Open();

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        long materiaId = Convert.ToInt64(result);
                        CargarAlumnosDeMateria(materiaId);
                    }
                }
            }
        }
    }
}
