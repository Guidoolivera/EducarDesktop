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
    public partial class NotasForm : Form
    {
        private MySqlConnection conexion;
        private long idUsuario;
        private string rolUsuario;

        public NotasForm(MySqlConnection conexion, long idUsuario, string rolUsuario)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.idUsuario = idUsuario;
            this.rolUsuario = rolUsuario;

            CargarCursos();
            CargarTrimestres();
        }

        private void CargarCursos()
        {
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
            try
            {
                string queryCursos = "SELECT id AS id_curso, nombre FROM curso";

                using (MySqlCommand cmd = new MySqlCommand(queryCursos, conexion))
                {
                    DataTable dataTable = new DataTable();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }

                    comboBoxCursos.DataSource = dataTable;
                    comboBoxCursos.DisplayMember = "nombre";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de cursos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarMaterias(long idCurso)
        {
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
            try
            {
                string queryMaterias =
                    "SELECT m.id AS id_materia, m.nombre " +
                    "FROM materia m " +
                    "WHERE curso_id = @idCurso";

                using (MySqlCommand cmd = new MySqlCommand(queryMaterias, conexion))
                {
                    cmd.Parameters.AddWithValue("@idCurso", idCurso);
                    DataTable materiasTable = new DataTable();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(materiasTable);
                    }

                    comboBoxMaterias.DataSource = materiasTable;
                    comboBoxMaterias.DisplayMember = "nombre";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de materias: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarAlumnos(long idMateria)
        {
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
            try
            {
                string queryAlumnos = "";

                if (rolUsuario == "Alumno" || rolUsuario == "Padre")
                {
                    queryAlumnos = "SELECT p.id AS id_alumno, CONCAT(p.apellido, ', ', p.nombre) AS nombre_completo " +
                        "FROM persona p " +
                        "INNER JOIN persona_has_materia phm ON p.id = phm.persona_id " +
                        "WHERE p.id = @idUsuario AND phm.materia_id = @idMateria";
                }
                else if (rolUsuario == "Profesor")
                {
                    queryAlumnos = "SELECT p.id AS id_alumno, CONCAT(p.apellido, ', ', p.nombre) AS nombre_completo " +
                        "FROM persona p " +
                        "INNER JOIN persona_has_materia phm ON p.id = phm.persona_id " +
                        "WHERE phm.materia_id = @idMateria";
                }
                else if (rolUsuario == "Directivo" || rolUsuario == "Administrador")
                {
                    queryAlumnos = "SELECT p.id AS id_alumno, CONCAT(p.apellido, ', ', p.nombre) AS nombre_completo " +
                        "FROM persona p " +
                        "INNER JOIN persona_has_materia phm ON p.id = phm.persona_id " +
                        "WHERE phm.materia_id = @idMateria";
                }

                using (MySqlCommand cmd = new MySqlCommand(queryAlumnos, conexion))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@idMateria", idMateria);
                    DataTable alumnosTable = new DataTable();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(alumnosTable);
                    }

                    // ComboBox para alumnos
                    comboBoxAlumnos.DataSource = alumnosTable;
                    comboBoxAlumnos.DisplayMember = "nombre_completo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de alumnos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTrimestres()
        {
            // Cargar números de trimestre en el comboBox
            comboBoxTrimestre.Items.Add(1);
            comboBoxTrimestre.Items.Add(2);
            comboBoxTrimestre.Items.Add(3);
            comboBoxTrimestre.SelectedIndex = 0; // Establecer el primer trimestre como selección inicial
        }

        private void btnGuardarNotas_Click(object sender, EventArgs e)
        {
            DataRowView selectedMateria = (DataRowView)comboBoxMaterias.SelectedItem;
            DataRowView selectedAlumno = (DataRowView)comboBoxAlumnos.SelectedItem;
            int trimestre = Convert.ToInt32(comboBoxTrimestre.SelectedItem); // Obtiene el trimestre seleccionado
            int nota = Convert.ToInt32(txtNota.Text);

            if (selectedMateria != null && selectedAlumno != null)
            {
                long idMateria = Convert.ToInt64(selectedMateria["id_materia"]);
                long idAlumno = Convert.ToInt64(selectedAlumno["id_alumno"]);

                // Llama a la función para guardar la nota en el trimestre correspondiente
                GuardarNotas(idAlumno, idMateria, trimestre, nota);
            }
            else
            {
                MessageBox.Show("Selecciona una materia y un alumno de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GuardarNotas(long idAlumno, long idMateria, int trimestre, int nota)
        {
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conexion;

                    // Verifica si ya existe un registro para este alumno y materia
                    cmd.CommandText = "SELECT COUNT(*) FROM persona_has_materia WHERE persona_id = @idAlumno AND materia_id = @idMateria";

                    cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                    cmd.Parameters.AddWithValue("@idMateria", idMateria);

                    int existeRegistro = Convert.ToInt32(cmd.ExecuteScalar());

                    if (existeRegistro > 0)
                    {
                        // Actualiza la nota en el trimestre correspondiente
                        cmd.CommandText = "UPDATE persona_has_materia SET Trimestre" + trimestre + " = @nota WHERE persona_id = @idAlumno AND materia_id = @idMateria";
                    }
                    else
                    {
                        // Inserta un nuevo registro y establece la nota en el trimestre correspondiente
                        cmd.CommandText = "INSERT INTO persona_has_materia (persona_id, materia_id, Trimestre" + trimestre + ") VALUES (@idAlumno, @idMateria, @nota)";
                    }

                    // Verifica que la nota esté dentro del rango permitido (1-10)
                    if (nota >= 1 && nota <= 10)
                    {
                        cmd.Parameters.AddWithValue("@nota", nota);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Nota guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("La nota debe estar en el rango de 1 a 10.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la nota: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedCurso = (DataRowView)comboBoxCursos.SelectedItem;

            if (selectedCurso != null)
            {
                long idCurso = Convert.ToInt64(selectedCurso["id_curso"]);
                CargarMaterias(idCurso);
            }
        }

        private void comboBoxMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Limpiar el comboBoxAlumnos al cambiar la materia seleccionada
            comboBoxAlumnos.DataSource = null;
            comboBoxAlumnos.Items.Clear();

            DataRowView selectedMateria = (DataRowView)comboBoxMaterias.SelectedItem;

            if (selectedMateria != null)
            {
                long idMateria = Convert.ToInt64(selectedMateria["id_materia"]);
                CargarAlumnos(idMateria);
            }
        }
    }
}