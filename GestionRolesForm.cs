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

                // Define la consulta SQL para actualizar el rol en la tabla "persona"
                string consultaActualizarRol = "UPDATE persona SET rol = @nuevoRol WHERE id = @idPersona";

                // Ejecuta la consulta para actualizar el rol
                using (MySqlCommand cmdActualizarRol = new MySqlCommand(consultaActualizarRol, conexion))
                {
                    cmdActualizarRol.Parameters.AddWithValue("@nuevoRol", nuevoRol);
                    cmdActualizarRol.Parameters.AddWithValue("@idPersona", idPersona);

                    int filasActualizadas = cmdActualizarRol.ExecuteNonQuery();

                    if (filasActualizadas > 0)
                    {
                        // Crear la entidad correspondiente según el nuevo rol
                        CrearEntidadSegunRol(idPersona, nuevoRol);

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

        private void CrearEntidadSegunRol(int idPersona, string nuevoRol)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                // Obtén los datos de la persona (nombre y apellido) por su ID
                string nombre = ObtenerNombrePersona(idPersona);
                string apellido = ObtenerApellidoPersona(idPersona);

                // Define la consulta SQL para insertar la nueva entidad según el rol
                string consultaInsertarEntidad = "";

                switch (nuevoRol)
                {
                    case "Alumno":
                        consultaInsertarEntidad = "INSERT INTO alumno (id, nombre, apellido) VALUES (@idPersona, @nombre, @apellido)";
                        break;
                    case "Padre":
                        consultaInsertarEntidad = "INSERT INTO padre (id, nombre, apellido) VALUES (@idPersona, @nombre, @apellido)";
                        break;
                    case "Docente":
                        consultaInsertarEntidad = "INSERT INTO docente (id, nombre, apellido) VALUES (@idPersona, @nombre, @apellido)";
                        break;
                    case "Directivo":
                        consultaInsertarEntidad = "INSERT INTO directivo (id, nombre, apellido) VALUES (@idPersona, @nombre, @apellido)";
                        break;
                    default:
                        // En caso de un rol no reconocido, no crear ninguna entidad
                        return;
                }

                using (MySqlCommand cmdInsertarEntidad = new MySqlCommand(consultaInsertarEntidad, conexion))
                {
                    cmdInsertarEntidad.Parameters.AddWithValue("@idPersona", idPersona);
                    cmdInsertarEntidad.Parameters.AddWithValue("@nombre", nombre);
                    cmdInsertarEntidad.Parameters.AddWithValue("@apellido", apellido);

                    int filasInsertadas = cmdInsertarEntidad.ExecuteNonQuery();

                    if (filasInsertadas > 0)
                    {
                        MessageBox.Show("Nueva entidad insertada correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo insertar la nueva entidad.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear nueva entidad: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        private string ObtenerNombrePersona(int idPersona)
        {
            string nombre = string.Empty;

            try
            {
                // Define la consulta SQL para obtener el nombre de la persona por su ID
                string consulta = "SELECT nombre FROM persona WHERE id = @idPersona";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@idPersona", idPersona);

                    // Ejecuta la consulta y obtiene el nombre de la persona
                    nombre = cmd.ExecuteScalar() as string;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el nombre: " + ex.Message);
            }

            return nombre;
        }

        private string ObtenerApellidoPersona(int idPersona)
        {
            string apellido = string.Empty;

            try
            {
                // Define la consulta SQL para obtener el apellido de la persona por su ID
                string consulta = "SELECT apellido FROM persona WHERE id = @idPersona";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@idPersona", idPersona);

                    // Ejecuta la consulta y obtiene el apellido de la persona
                    apellido = cmd.ExecuteScalar() as string;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el apellido: " + ex.Message);
            }

            return apellido;
        }
    }
}
