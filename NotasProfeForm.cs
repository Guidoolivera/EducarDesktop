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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una materia y un alumno antes de agregar una nota.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int calificacion))
            {
                MessageBox.Show("Ingresa una calificación válida.");
                return;
            }

            string materiaSeleccionada = comboBox1.SelectedItem.ToString();
            string alumnoSeleccionado = comboBox2.SelectedItem.ToString();

            // Obtener el ID de la materia
            string consultaMateria = "SELECT id FROM materia WHERE nombre = @nombreMateria";
            using (MySqlCommand cmdMateria = new MySqlCommand(consultaMateria, conexion))
            {
                cmdMateria.Parameters.AddWithValue("@nombreMateria", materiaSeleccionada);
                if (conexion.State == ConnectionState.Closed)
                    conexion.Open();
                object resultMateria = cmdMateria.ExecuteScalar();
                if (resultMateria == null)
                {
                    MessageBox.Show("No se encontró el ID de la materia.");
                    return;
                }
                long materiaId = Convert.ToInt64(resultMateria);

                // Obtener el ID del alumno
                string consultaAlumno = "SELECT id FROM persona WHERE CONCAT(nombre, ' ', apellido) = @nombreAlumno";
                using (MySqlCommand cmdAlumno = new MySqlCommand(consultaAlumno, conexion))
                {
                    cmdAlumno.Parameters.AddWithValue("@nombreAlumno", alumnoSeleccionado);
                    object resultAlumno = cmdAlumno.ExecuteScalar();
                    if (resultAlumno == null)
                    {
                        MessageBox.Show("No se encontró el ID del alumno.");
                        return;
                    }
                    long alumnoId = Convert.ToInt64(resultAlumno);

                    // Insertar la calificación en la tabla 'nota'
                    string consultaInsert = "INSERT INTO nota (calificacion, fecha, materia_id, persona_id) " +
                                            "VALUES (@calificacion, @fecha, @materiaId, @alumnoId)";
                    using (MySqlCommand cmdInsert = new MySqlCommand(consultaInsert, conexion))
                    {
                        cmdInsert.Parameters.AddWithValue("@calificacion", calificacion);
                        cmdInsert.Parameters.AddWithValue("@fecha", DateTime.Now);
                        cmdInsert.Parameters.AddWithValue("@materiaId", materiaId);
                        cmdInsert.Parameters.AddWithValue("@alumnoId", alumnoId);

                        if (conexion.State == ConnectionState.Closed)
                            conexion.Open();

                        int rowsAffected = cmdInsert.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Calificación agregada con éxito.");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar la calificación.");
                        }
                    }
                }
            }
            actualizarDataGridView();
        }
        
    }
}
