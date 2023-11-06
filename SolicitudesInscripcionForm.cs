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
    public partial class SolicitudesInscripcionForm : Form
    {
        private readonly MySqlConnection conexion;
        private readonly long idUsuario;
        private readonly string rolUsuario;

        public SolicitudesInscripcionForm(MySqlConnection conexion, long idUsuario, string rolUsuario)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.idUsuario = idUsuario;
            this.rolUsuario = rolUsuario;
            CargarSolicitudesPendientes();
        }

        private void CargarSolicitudesPendientes()
        {
            string querySolicitudesPendientes =
                "SELECT s.id, s.id_alumno, s.id_materia, s.fecha_solicitud, p.nombre AS nombre_alumno, m.nombre AS nombre_materia " +
                "FROM solicitudes_inscripcion s " +
                "INNER JOIN persona p ON s.id_alumno = p.id " +
                "INNER JOIN materia m ON s.id_materia = m.id";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(querySolicitudesPendientes, conexion))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Enlazar el DataGridView con los datos de las solicitudes pendientes
                        dgvSolicitudes.DataSource = dataTable;

                        // Renombrar las columnas del DataGridView
                        dgvSolicitudes.Columns["fecha_solicitud"].HeaderText = "Fecha de Solicitud";
                        dgvSolicitudes.Columns["nombre_alumno"].HeaderText = "Alumno";
                        dgvSolicitudes.Columns["nombre_materia"].HeaderText = "Materia";

                        // Ocultar las columnas "id", "id_alumno" e "id_materia"
                        dgvSolicitudes.Columns["id"].Visible = false;
                        dgvSolicitudes.Columns["id_alumno"].Visible = false;
                        dgvSolicitudes.Columns["id_materia"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las solicitudes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AceptarSolicitud(int solicitudId, int idAlumno, int idMateria)
        {
            try
            {
                // Realizar la inserción en la tabla "persona_has_materia"
                string queryInsercion = "INSERT INTO persona_has_materia (persona_id, materia_id, fecha_inscripcion) " +
                                        "VALUES (@idAlumno, @idMateria, NOW())";

                using (MySqlCommand cmd = new MySqlCommand(queryInsercion, conexion))
                {
                    cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                    cmd.Parameters.AddWithValue("@idMateria", idMateria);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        // Eliminar la solicitud aceptada de la tabla "solicitudes_inscripcion"
                        string queryEliminarSolicitud = "DELETE FROM solicitudes_inscripcion WHERE id = @solicitudId";

                        using (MySqlCommand cmdEliminar = new MySqlCommand(queryEliminarSolicitud, conexion))
                        {
                            cmdEliminar.Parameters.AddWithValue("@solicitudId", solicitudId);
                            cmdEliminar.ExecuteNonQuery();
                        }

                        // Recargar las solicitudes pendientes en el DataGridView
                        CargarSolicitudesPendientes();

                        MessageBox.Show("Solicitud aceptada y procesada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al procesar la solicitud.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aceptar la solicitud: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RechazarSolicitud(int solicitudId)
        {
            try
            {
                // Eliminar la solicitud rechazada de la tabla "solicitudes_inscripcion"
                string queryEliminarSolicitud = "DELETE FROM solicitudes_inscripcion WHERE id = @solicitudId";

                using (MySqlCommand cmdEliminar = new MySqlCommand(queryEliminarSolicitud, conexion))
                {
                    cmdEliminar.Parameters.AddWithValue("@solicitudId", solicitudId);
                    cmdEliminar.ExecuteNonQuery();

                    // Recargar las solicitudes pendientes en el DataGridView
                    CargarSolicitudesPendientes();

                    MessageBox.Show("Solicitud rechazada y eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al rechazar la solicitud: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_AceptarSolicitud_Click(object sender, EventArgs e)
        {
            if (dgvSolicitudes.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de aceptar esta solicitud?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int solicitudId = Convert.ToInt32(dgvSolicitudes.SelectedRows[0].Cells["id"].Value);
                    int idAlumno = Convert.ToInt32(dgvSolicitudes.SelectedRows[0].Cells["id_alumno"].Value);
                    int idMateria = Convert.ToInt32(dgvSolicitudes.SelectedRows[0].Cells["id_materia"].Value);

                    AceptarSolicitud(solicitudId, idAlumno, idMateria);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una solicitud antes de aceptarla.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_RechazarSolicitud_Click(object sender, EventArgs e)
        {
            if (dgvSolicitudes.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de rechazar esta solicitud?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int solicitudId = Convert.ToInt32(dgvSolicitudes.SelectedRows[0].Cells["id"].Value);
                    RechazarSolicitud(solicitudId);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una solicitud antes de rechazarla.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}