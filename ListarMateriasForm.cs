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
        }

        /*
        private void ListarMateriasForm_Load(object sender, EventArgs e)
        {
            // Consulta para obtener las materias y la cantidad de alumnos inscritos
            string query = "SELECT m.id AS MateriaId, m.nombre AS MateriaNombre, a.nombre AS AlumnoNombre " +
                           "FROM materia m " +
                           "LEFT JOIN inscripciones i ON m.id = i.idmateria " +
                           "LEFT JOIN alumno a ON i.idalumno = a.id " +
                           "ORDER BY m.id";

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion))
            {
                DataTable tablaMaterias = new DataTable();
                adapter.Fill(tablaMaterias);

                // Asignar la tabla de datos al DataGridView
                dataGridViewMaterias.DataSource = tablaMaterias;

                // Habilitar la autogeneración de columnas (excepto la del ComboBox)
                dataGridViewMaterias.AutoGenerateColumns = true;

                // Crear una columna de ComboBox manualmente
                DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                comboBoxColumn.HeaderText = "Alumnos Inscritos";
                comboBoxColumn.Name = "cmbAlumnos";
                comboBoxColumn.DataPropertyName = "AlumnoNombre"; // Nombre de la columna en el DataTable

                // Agregar la columna del ComboBox al DataGridView
                dataGridViewMaterias.Columns.Add(comboBoxColumn);

                // Llenar el ComboBox con los nombres de los alumnos
                foreach (DataGridViewRow row in dataGridViewMaterias.Rows)
                {
                    DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)row.Cells["cmbAlumnos"];
                    comboBoxCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                    comboBoxCell.ValueMember = "AlumnoNombre"; // Nombre de la columna en el DataTable
                    comboBoxCell.DataSource = tablaMaterias;
                    comboBoxCell.Value = row.Cells["AlumnoNombre"].Value;
                }
            }
        }
        */

        private void dataGridViewMaterias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificar si se está formateando una celda en la columna de ComboBox
            if (dataGridViewMaterias.Columns[e.ColumnIndex].Name == "cmbAlumnos" && e.RowIndex >= 0)
            {
                DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)dataGridViewMaterias.Rows[e.RowIndex].Cells["cmbAlumnos"];
                comboBoxCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            }
        }


    }
}