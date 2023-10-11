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
    public partial class GestionRolesForm : Form
    {
        private MySqlConnection conexion;

        public GestionRolesForm(MySqlConnection conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
        }

        private void GestionRolesForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine("El formulario se ha cargado correctamente.");
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                using (conexion)
                {
                    if (conexion.State != ConnectionState.Open)
                    {
                        conexion.Open();
                    }

                    string consulta = "SELECT id, nombre, apellido, rol FROM persona";

                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion))
                    {
                        DataTable tablaPersonas = new DataTable();
                        adaptador.Fill(tablaPersonas);

                        dataGridView1.DataSource = tablaPersonas;

                        // Configura las columnas manualmente
                        ConfigurarColumna("id", "ID", false);
                        ConfigurarColumna("nombre", "Nombre", true);
                        ConfigurarColumna("apellido", "Apellido", true);

                        // Agregar una columna de ComboBox para seleccionar el rol
                        AgregarComboBoxColumn("rol", "Seleccionar Rol", "cmbRol", new[] { "Default", "Administrador", "Padre", "Alumno", "Profesor", "Directivo" });
                    }

                    // Suscribir al evento CellEndEdit
                    dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ConfigurarColumna(string nombreColumna, string encabezado, bool visible)
        {
            if (dataGridView1.Columns.Contains(nombreColumna))
            {
                dataGridView1.Columns[nombreColumna].HeaderText = encabezado;
                dataGridView1.Columns[nombreColumna].Visible = visible;
            }
        }

        private void AgregarComboBoxColumn(string dataPropertyName, string headerText, string name, string[] dataSource)
        {
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.DataPropertyName = dataPropertyName;
            comboBoxColumn.HeaderText = headerText;
            comboBoxColumn.Name = name;
            comboBoxColumn.DataSource = dataSource;
            dataGridView1.Columns.Add(comboBoxColumn);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["cmbRol"].Index && e.RowIndex >= 0)
            {
                DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells["cmbRol"];
                string rolSeleccionado = comboBoxCell.Value.ToString();
                int idPersona = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);

                ActualizarRolEnBaseDeDatos(idPersona, rolSeleccionado);
            }
        }

        private void ActualizarRolEnBaseDeDatos(int idPersona, string nuevoRol)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                string consultaActualizarRol = "UPDATE persona SET rol = @nuevoRol WHERE id = @idPersona";
                using (MySqlCommand cmdActualizarRol = new MySqlCommand(consultaActualizarRol, conexion))
                {
                    cmdActualizarRol.Parameters.AddWithValue("@nuevoRol", nuevoRol);
                    cmdActualizarRol.Parameters.AddWithValue("@idPersona", idPersona);
                    cmdActualizarRol.ExecuteNonQuery();
                }

                Console.WriteLine("Rol actualizado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
    }
}