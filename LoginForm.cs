using EducarWeb.Clases;
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
    public partial class LoginForm : Form
    {
        private readonly Clases.Conexion objetoConexion;

        public LoginForm()
        {
            InitializeComponent();
            objetoConexion = new Clases.Conexion();
        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            string username = tb_Username.Text;
            string password = tb_Password.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingrese un nombre de usuario y una contraseña válidos.");
                return;
            }

            using (MySqlConnection conexion = objetoConexion.establecerConexion())
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                string query = "SELECT COUNT(*), is_staff, id, first_name, last_name, email FROM usuario_usuario WHERE username = @username AND password = @password";
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int count = reader.GetInt32(0);
                            if (count > 0)
                            {
                                bool isAdmin = reader.IsDBNull(1) ? false : reader.GetBoolean(1);

                                MessageBox.Show(isAdmin ? "Inicio de sesión exitoso como administrador." : "Inicio de sesión exitoso como usuario no administrador.");

                                long idUsuario = reader.GetInt64(2);
                                string nombreUsuario = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                                string apellidoUsuario = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                                string emailUsuario = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);

                                // Cerrar el DataReader antes de llamar a CrearPersona
                                reader.Close();

                                // Determinar el rol del usuario
                                string rolUsuario = isAdmin ? "Administrador" : "Default";

                                if (!PersonaExiste(conexion, idUsuario))
                                {
                                    if (CrearPersona(conexion, idUsuario, nombreUsuario, apellidoUsuario, username, emailUsuario, rolUsuario))
                                    {
                                        MessageBox.Show("Datos de persona guardados correctamente.");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error al guardar datos de persona.");
                                    }
                                }

                                MainForm mainForm = new MainForm(username, isAdmin, conexion, idUsuario);
                                mainForm.ShowDialog();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
                        }
                    }
                }
            }
        }

        private bool PersonaExiste(MySqlConnection conexion, long idUsuario)
        {
            string queryPersonaExistente = "SELECT COUNT(*) FROM persona WHERE id = @id";
            MySqlCommand cmdPersonaExistente = new MySqlCommand(queryPersonaExistente, conexion);
            cmdPersonaExistente.Parameters.AddWithValue("@id", idUsuario);

            try
            {
                int countPersonaExistente = Convert.ToInt32(cmdPersonaExistente.ExecuteScalar());

                return countPersonaExistente > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al verificar la existencia de la persona: " + ex.Message);
                return false;
            }
        }

        private bool CrearPersona(MySqlConnection conexion, long idUsuario, string nombreUsuario, string apellidoUsuario, string username, string emailUsuario, string rolUsuario)
        {
            string queryInsertarPersona = "INSERT INTO persona (id, nombre, apellido, username, email, rol) VALUES (@id, @nombre, @apellido, @username, @email, @rol)";

            try
            {
                using (MySqlCommand cmdInsertarPersona = new MySqlCommand(queryInsertarPersona, conexion))
                {
                    cmdInsertarPersona.Parameters.AddWithValue("@id", idUsuario);
                    cmdInsertarPersona.Parameters.AddWithValue("@nombre", nombreUsuario);
                    cmdInsertarPersona.Parameters.AddWithValue("@apellido", apellidoUsuario);
                    cmdInsertarPersona.Parameters.AddWithValue("@username", username);
                    cmdInsertarPersona.Parameters.AddWithValue("@email", emailUsuario);
                    cmdInsertarPersona.Parameters.AddWithValue("@rol", rolUsuario);

                    int filasAfectadas = cmdInsertarPersona.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al crear la persona: " + ex.Message);
                return false;
            }
        }
    }
}