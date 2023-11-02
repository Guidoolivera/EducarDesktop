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
    public partial class CrearMateriaForm : Form
    {
        private readonly MySqlConnection conexion;
        long idUsuario;
        string rolUsuario;

        public CrearMateriaForm(MySqlConnection conexion, long idUsuario, string rolUsuario)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.idUsuario = idUsuario;
            this.rolUsuario = rolUsuario;
            CargarProfesores();
            CargarCursos(); // Llamar al método para cargar los cursos al inicializar el formulario
        }

        private void CargarProfesores()
        {
            string queryProfesores = "SELECT id, nombre, apellido FROM persona WHERE rol = 'Profesor'";

            using (MySqlCommand cmd = new MySqlCommand(queryProfesores, conexion))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    comboBoxProfesores.DataSource = dataTable;
                    comboBoxProfesores.DisplayMember = "nombre";
                    comboBoxProfesores.ValueMember = "id";
                }
            }
        }

        private void CargarCursos()
        {
            string queryCursos = "SELECT id, nombre FROM curso"; // Modificar según tu estructura de datos

            using (MySqlCommand cmd = new MySqlCommand(queryCursos, conexion))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    comboBoxCursos.DataSource = dataTable;
                    comboBoxCursos.DisplayMember = "nombre"; // Modificar si el campo es diferente
                    comboBoxCursos.ValueMember = "id"; // El ID del curso
                }
            }
        }

        private void btn_CrearMateria_Click(object sender, EventArgs e)
        {
            string nombre = tb_NombreMateria.Text;
            string descripcion = tb_DescripcionMateria.Text;
            int cupoMaximo;
            int cursoId;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(descripcion) || !int.TryParse(tb_CupoMaximo.Text, out cupoMaximo) || comboBoxCursos.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos y asegúrese de ingresar un valor válido en el campo 'Cupo Máximo'.");
                return;
            }

            cursoId = Convert.ToInt32(comboBoxCursos.SelectedValue);

            string fechaInicio = dtp_FechaInicio.Value.ToString("yyyy-MM-dd");
            string fechaFin = dtp_FechaFin.Value.ToString("yyyy-MM-dd");
            string horarios = tb_Horarios.Text;
            long profesorId = Convert.ToInt64(comboBoxProfesores.SelectedValue);

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            string queryInsercion = "INSERT INTO materia (nombre, descripcion, cupo_maximo, fecha_inicio, fecha_fin, horarios, profesor_id, curso_id) " +
                                    "VALUES (@nombre, @descripcion, @cupoMaximo, @fechaInicio, @fechaFin, @horarios, @profesorId, @cursoId)";

            using (MySqlCommand cmd = new MySqlCommand(queryInsercion, conexion))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@cupoMaximo", cupoMaximo);
                cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                cmd.Parameters.AddWithValue("@horarios", horarios);
                cmd.Parameters.AddWithValue("@profesorId", profesorId);
                cmd.Parameters.AddWithValue("@cursoId", cursoId);

                try
                {
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Materia creada exitosamente.");
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error al crear la materia.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LimpiarCampos()
        {
            tb_NombreMateria.Clear();
            tb_DescripcionMateria.Clear();
            tb_CupoMaximo.Clear();
            dtp_FechaInicio.Value = DateTime.Today;
            dtp_FechaFin.Value = DateTime.Today;
            tb_Horarios.Clear();
        }
    }
}