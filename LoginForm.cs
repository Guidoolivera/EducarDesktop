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
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            string username = tb_Username.Text;
            string password = tb_Password.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                Clases.Conexion objetoConexion = new Clases.Conexion();
                using (MySqlConnection conexion = objetoConexion.establecerConexion())
                {
                    string query = "SELECT COUNT(*) FROM usuario_usuario WHERE username = @username AND password = @password AND is_staff = 1";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Inicio de sesión exitoso como administrador.");
                        if (!PersonaExiste(conexion, username))
                        {
                            if (CrearPersona(conexion, username)) // Verifica si la creación de persona fue exitosa
                            {
                                MessageBox.Show("Datos de persona guardados correctamente.");
                            }
                            else
                            {
                                MessageBox.Show("Error al guardar datos de persona.");
                            }
                        }
                        MainForm mainForm = new MainForm(username, true, conexion);
                        mainForm.ShowDialog();
                        this.Hide();
                    }
                    else
                    {
                        string querySinIsStaff = "SELECT COUNT(*) FROM usuario_usuario WHERE username = @username AND password = @password";
                        MySqlCommand cmdSinIsStaff = new MySqlCommand(querySinIsStaff, conexion);
                        cmdSinIsStaff.Parameters.AddWithValue("@username", username);
                        cmdSinIsStaff.Parameters.AddWithValue("@password", password);

                        int countSinIsStaff = Convert.ToInt32(cmdSinIsStaff.ExecuteScalar());

                        if (countSinIsStaff > 0)
                        {
                            MessageBox.Show("Inicio de sesión exitoso como usuario no administrador.");
                            if (!PersonaExiste(conexion, username))
                            {
                                if (CrearPersona(conexion, username)) // Verifica si la creación de persona fue exitosa
                                {
                                    MessageBox.Show("Datos de persona guardados correctamente.");
                                }
                                else
                                {
                                    MessageBox.Show("Error al guardar datos de persona.");
                                }
                            }

                            MainForm mainForm = new MainForm(username, false, conexion);
                            mainForm.ShowDialog();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un nombre de usuario y una contraseña válidos.");
            }
        }

        private bool PersonaExiste(MySqlConnection conexion, string username)
        {
            string queryPersonaExistente = "SELECT COUNT(*) FROM persona WHERE username = @username";
            MySqlCommand cmdPersonaExistente = new MySqlCommand(queryPersonaExistente, conexion);
            cmdPersonaExistente.Parameters.AddWithValue("@username", username);

            int countPersonaExistente = Convert.ToInt32(cmdPersonaExistente.ExecuteScalar());

            return countPersonaExistente > 0;
        }

        // Método para crear una nueva persona en la tabla "persona"
        private bool CrearPersona(MySqlConnection conexion, string username)
        {
            // Obtener los datos de la persona desde la tabla usuario_usuario
            string queryObtenerDatosUsuario = "SELECT id, first_name, last_name, email FROM usuario_usuario WHERE username = @username";

            using (MySqlCommand cmdObtenerDatosUsuario = new MySqlCommand(queryObtenerDatosUsuario, conexion))
            {
                cmdObtenerDatosUsuario.Parameters.AddWithValue("@username", username);

                using (MySqlDataReader reader = cmdObtenerDatosUsuario.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        long idUsuario = reader.GetInt64("id");
                        string nombreUsuario = reader.GetString("first_name");
                        string apellidoUsuario = reader.GetString("last_name");
                        string emailUsuario = reader.GetString("email");
 

                        // Verificar si el valor de 'username' no es nulo o vacío
                        if (!string.IsNullOrEmpty(username))
                        {
                            // Crear un nuevo objeto Persona
                            Persona persona = new Persona(idUsuario,nombreUsuario, apellidoUsuario, username, emailUsuario);

                            // Insertar la nueva persona en la tabla "persona"
                            string queryInsertarPersona = "INSERT INTO persona (id, nombre, apellido, username, email) VALUES (@id, @nombre, @apellido, @username, @email)";

                            using (MySqlCommand cmdInsertarPersona = new MySqlCommand(queryInsertarPersona, conexion))
                            {
                                cmdInsertarPersona.Parameters.AddWithValue("@id", persona.Id);
                                cmdInsertarPersona.Parameters.AddWithValue("@nombre", persona.Nombre);
                                cmdInsertarPersona.Parameters.AddWithValue("@apellido", persona.Apellido);
                                cmdInsertarPersona.Parameters.AddWithValue("@username", persona.Username);
                                cmdInsertarPersona.Parameters.AddWithValue("@email", persona.Email);

                                // Cerrar el DataReader antes de ejecutar una nueva consulta
                                reader.Close();

                                int filasAfectadas = cmdInsertarPersona.ExecuteNonQuery();

                                return filasAfectadas > 0;
                            }
                        }
                        else
                        {
                            MessageBox.Show("El valor de 'username' es nulo o vacío. No se pudo crear la persona.");
                        }
                    }
                }
            }

            return false;
        }
    }
}