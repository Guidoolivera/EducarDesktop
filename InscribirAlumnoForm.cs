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
        MySqlConnection conexion;

        public InscribirAlumnoForm(MySqlConnection conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
        }

        private void ListarMateriasForm_Load(object sender, EventArgs e)
        {
            CargarMaterias();
        }

        private void CargarMaterias()
        {
            // Realizar la consulta SQL para obtener la lista de materias
            string queryListado = "SELECT id AS IdMateria, nombre AS NombreMateria FROM materia";

            using (MySqlCommand cmd = new MySqlCommand(queryListado, conexion))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Enlazar el ComboBox con los datos de las materias
                    comboBoxMaterias.DataSource = dataTable;
                    comboBoxMaterias.DisplayMember = "NombreMateria";
                    comboBoxMaterias.ValueMember = "IdMateria";
                }
            }
        }

        private void btn_InscribirAlumno_Click(object sender, EventArgs e)
        {
            // Obtener el valor del TextBox tb_idAlumno
            if (int.TryParse(tb_idAlumno.Text, out int idAlumno))
            {
                if (comboBoxMaterias.SelectedIndex != -1)
                {
                    int idMateria = Convert.ToInt32(comboBoxMaterias.SelectedValue);

                    // Realizar la inserción en la tabla de inscripciones
                    string queryInsercion = "INSERT INTO inscripciones (idalumno, idmateria) VALUES (@idAlumno, @idMateria)";

                    using (MySqlCommand cmd = new MySqlCommand(queryInsercion, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                        cmd.Parameters.AddWithValue("@idMateria", idMateria);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Inscripción exitosa.");
                        }
                        else
                        {
                            MessageBox.Show("Error al inscribirse en la materia.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona una materia antes de inscribirte.");
                }
            }
            else
            {
                MessageBox.Show("Ingresa un ID de alumno válido.");
            }
        }
    }
}
