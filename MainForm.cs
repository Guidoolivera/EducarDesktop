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
    public partial class MainForm : Form
    {
        bool esAdmin;
        MySqlConnection conexion;
        long idUsuario;
        public MainForm(string username, bool esAdmin, MySqlConnection conexion, long idUsuario)
        {
            InitializeComponent();
            lbl_bienvenido.Text = "Bienvenido, " + username + ".";
            this.esAdmin = esAdmin;
            this.conexion = conexion; 
            this.idUsuario = idUsuario; 
        }

        private void btn_Materias_Click(object sender, EventArgs e)
        {
            MateriaForm materiaForm = new MateriaForm(conexion, idUsuario); // Pasa la conexión
            materiaForm.ShowDialog();
        }

        private void btn_GestionarRoles_Click(object sender, EventArgs e)
        {
            GestionRolesForm grf = new GestionRolesForm(conexion);
            grf.ShowDialog();
        }

        private void btn_Pagos_Click(object sender, EventArgs e)
        {
            PagoForm pagoForm = new PagoForm(conexion); // Pasa la conexión
            pagoForm.ShowDialog();
        }

        private void btn_Examenes_Click(object sender, EventArgs e)
        {
            if (esprofe(idUsuario, conexion))
            {
                //abrir la ventana para igresar notas. ventana de profes
                NotasProfeForm notasProfe = new NotasProfeForm(idUsuario, conexion);
                notasProfe.ShowDialog();
            }
            else
            {
                //ventana de vista de las notas del alumno
                NotasAlumnoForm notasAlumno = new NotasAlumnoForm(idUsuario, conexion);
                notasAlumno.ShowDialog();
            }
        }

        public bool esprofe(long idUsuario, MySqlConnection conexion)
        {
            bool esProfe=false;
            string consulta = "SELECT rol FROM persona WHERE id = @idUsuario";
            
            using (conexion)
            {
                
                MySqlCommand cmd = new MySqlCommand(consulta, conexion);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string rol = reader["rol"].ToString();
                        if (rol == "Profesor")
                        {
                            esProfe = true;
                        }
                    }
                }
                
            }
            return esProfe;
        }
    }
}
