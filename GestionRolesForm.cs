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
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                string consulta = "SELECT id, nombre, apellido, rol FROM persona";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
                DataTable tablaPersonas = new DataTable();
                adaptador.Fill(tablaPersonas);

                dataGridView1.DataSource = tablaPersonas;

                // Configura las columnas manualmente
                ConfigurarColumna("id", "ID", false);
                ConfigurarColumna("nombre", "Nombre", true);
                ConfigurarColumna("apellido", "Apellido", true);

                // Agregar una columna de ComboBox para seleccionar el rol
                DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                comboBoxColumn.DataPropertyName = "rol";
                comboBoxColumn.HeaderText = "Seleccionar Rol";
                comboBoxColumn.Name = "cmbRol";
                comboBoxColumn.DataSource = new[] { "Alumno", "Padre", "Docente", "Directivo" };
                dataGridView1.Columns.Add(comboBoxColumn);

                // Suscribir al evento CellEndEdit
                dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
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

        private void ConfigurarColumna(string nombreColumna, string encabezado, bool visible)
        {
            if (dataGridView1.Columns.Contains(nombreColumna))
            {
                dataGridView1.Columns[nombreColumna].HeaderText = encabezado;
                dataGridView1.Columns[nombreColumna].Visible = visible;
            }
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

                string consulta = "UPDATE persona SET rol = @nuevoRol WHERE id = @idPersona";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@nuevoRol", nuevoRol);
                    cmd.Parameters.AddWithValue("@idPersona", idPersona);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Rol actualizado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el rol.");
                    }
                }
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