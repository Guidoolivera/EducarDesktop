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
    public partial class ListarMateriasForm : Form
    {
        private MySqlConnection conexion;

        public ListarMateriasForm(MySqlConnection conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            CargarMaterias();
        }

        private void CargarMaterias()
        {
            try
            {
                string queryMaterias =
                    "SELECT m.id, m.nombre AS materia, p.nombre AS profesor, " +
                    "GROUP_CONCAT(pAlumno.nombre SEPARATOR ', ') AS alumnos, " +
                    "COUNT(phm.materia_id) AS cantidad_inscritos " +
                    "FROM materia m " +
                    "INNER JOIN persona p ON m.profesor_id = p.id " +
                    "LEFT JOIN persona_has_materia phm ON m.id = phm.materia_id " +
                    "LEFT JOIN persona pAlumno ON phm.persona_id = pAlumno.id " +
                    "WHERE p.rol = 'Profesor' " +
                    "GROUP BY m.id, m.nombre, p.nombre";

                using (MySqlCommand cmd = new MySqlCommand(queryMaterias, conexion))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Añadir una columna para mostrar la lista de alumnos inscritos
                        //dgvMaterias.Columns.Add("alumnos", "Alumnos Inscritos");

                        // Enlazar el DataGridView con los datos de las materias
                        dgvMaterias.DataSource = dataTable;

                        // Renombrar las columnas del DataGridView
                        dgvMaterias.Columns["id"].Visible = true;
                        dgvMaterias.Columns["id"].HeaderText = "Legajo";
                        dgvMaterias.Columns["materia"].HeaderText = "Materia";
                        dgvMaterias.Columns["profesor"].HeaderText = "Profesor";
                        //dgvMaterias.Columns["alumnos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;3
                        dgvMaterias.Columns["alumnos"].Visible = false;
                        dgvMaterias.Columns["cantidad_inscritos"].HeaderText = "Inscritos";

                        // Manejar el evento SelectionChanged para mostrar la lista de alumnos en el ListBox
                        dgvMaterias.SelectionChanged += dgvMaterias_SelectionChanged;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las materias: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMaterias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMaterias.SelectedRows.Count > 0)
            {
                int idMateria = Convert.ToInt32(dgvMaterias.SelectedRows[0].Cells["id"].Value);
                string materiaSeleccionada = dgvMaterias.SelectedRows[0].Cells["materia"].Value.ToString();

                try
                {
                    // Consulta para cargar la lista de alumnos inscritos
                    string queryAlumnosInscritos =
                        "SELECT p.nombre " +
                        "FROM persona p " +
                        "INNER JOIN persona_has_materia phm ON p.id = phm.persona_id " +
                        "WHERE phm.materia_id = @idMateria";

                    using (MySqlCommand cmd = new MySqlCommand(queryAlumnosInscritos, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idMateria", idMateria);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Mostrar la lista de alumnos inscritos en el ListBox
                            listBoxAlumnos.DataSource = dataTable;
                            listBoxAlumnos.DisplayMember = "nombre";

                            // Actualizar el título del ListBox
                            lblAlumnosInscritos.Text = $"Alumnos Inscritos en {materiaSeleccionada}:";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la lista de alumnos inscritos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}