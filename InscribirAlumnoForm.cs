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
    public partial class InscribirAlumnoForm : Form
    {
        private MySqlConnection conexion;
        private int idAlumno; // Debes asignar el ID del alumno que está solicitando inscripción

        public InscribirAlumnoForm(MySqlConnection conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
        }

        private void SolicitarInscripcionForm_Load(object sender, EventArgs e)
        {
            CargarMateriasDisponibles();
        }

        private void CargarMateriasDisponibles()
        {
            string query = "SELECT m.id, m.nombre, (m.cupo_maximo - IFNULL(i.cantidad_inscriptos, 0)) AS cupo_disponible " +
                           "FROM materia AS m " +
                           "LEFT JOIN (SELECT id_materia, COUNT(*) AS cantidad_inscriptos FROM persona_has_materia GROUP BY id_materia) AS i " +
                           "ON m.id = i.id_materia " +
                           "WHERE cupo_disponible > 0";

            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    comboBoxMaterias.DataSource = dataTable;
                    comboBoxMaterias.DisplayMember = "nombre";
                    comboBoxMaterias.ValueMember = "id";
                }
            }
        }

        private void btn_SolicitarInscripcion_Click(object sender, EventArgs e)
        {
            if (comboBoxMaterias.SelectedIndex != -1)
            {
                int idMateria = Convert.ToInt32(comboBoxMaterias.SelectedValue);
                DateTime fechaSolicitud = DateTime.Now;

                string query = "INSERT INTO solicitudes_inscripcion (id_alumno, id_materia, fecha_solicitud) VALUES (@idAlumno, @idMateria, @fechaSolicitud)";

                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                    cmd.Parameters.AddWithValue("@idMateria", idMateria);
                    cmd.Parameters.AddWithValue("@fechaSolicitud", fechaSolicitud);

                    try
                    {
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Solicitud de inscripción enviada.");
                        }
                        else
                        {
                            MessageBox.Show("Error al enviar la solicitud de inscripción.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al enviar la solicitud de inscripción: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una materia antes de enviar la solicitud.");
            }
        }
    }
}