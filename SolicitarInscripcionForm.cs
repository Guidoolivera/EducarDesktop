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
    public partial class SolicitarInscripcionForm : Form
    {
        private readonly long idUsuario;
        private readonly MySqlConnection conexion;

        public SolicitarInscripcionForm(MySqlConnection conexion, long idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.conexion = conexion;

            // Llamar al método de carga de materias disponibles durante la inicialización
            CargarMateriasDisponibles();
        }

        private void CargarMateriasDisponibles()
        {
            try
            {
                // Limpia los datos anteriores antes de cargar las nuevas materias disponibles
                comboBoxMaterias.DataSource = null;

                string queryMateriasDisponibles =
                    "SELECT m.id, m.nombre " +
                    "FROM materia m " +
                    "LEFT JOIN persona_has_materia phm ON m.id = phm.materia_id " +
                    "WHERE m.cupo_maximo > (SELECT COUNT(*) FROM persona_has_materia WHERE materia_id = m.id) " +
                    "AND (phm.persona_id <> @idUsuario OR phm.persona_id IS NULL) " +
                    "AND m.id NOT IN (SELECT id_materia FROM solicitudes_inscripcion WHERE id_alumno = @idUsuario)";

                using (MySqlCommand cmd = new MySqlCommand(queryMateriasDisponibles, conexion))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Enlazar el ComboBox con las materias disponibles
                        comboBoxMaterias.DataSource = dataTable;
                        comboBoxMaterias.DisplayMember = "nombre";
                        comboBoxMaterias.ValueMember = "id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las materias disponibles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_SolicitarInscripcion_Click(object sender, EventArgs e)
        {
            if (comboBoxMaterias.SelectedIndex != -1)
            {
                int idMateria = Convert.ToInt32(comboBoxMaterias.SelectedValue);

                // Realizar la inserción en la tabla "solicitudes_inscripcion" para solicitar la inscripción
                string queryInsercion = "INSERT INTO solicitudes_inscripcion (id_alumno, id_materia, fecha_solicitud) " +
                                        "VALUES (@idUsuario, @idMateria, NOW())";

                using (MySqlCommand cmd = new MySqlCommand(queryInsercion, conexion))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@idMateria", idMateria);

                    try
                    {
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Solicitud de inscripción enviada correctamente.");

                            // Actualizar las materias disponibles después de la solicitud
                            CargarMateriasDisponibles();
                        }
                        else
                        {
                            MessageBox.Show("Error al enviar la solicitud de inscripción.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al enviar la solicitud de inscripción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una materia antes de solicitar la inscripción.");
            }
        }
    }
}