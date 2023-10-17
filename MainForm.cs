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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            menuDesplegable.Visible = !menuDesplegable.Visible;
            btn_Materias.Visible = !btn_Materias.Visible;
            btn_Asistencia.Visible = !btn_Asistencia.Visible;
            btn_Examenes.Visible = !btn_Examenes.Visible;
            btn_Pagos.Visible=!btn_Pagos.Visible;
            btn_GestionarRoles.Visible = !btn_GestionarRoles.Visible;
            btn_Sobre.Visible = !btn_Sobre.Visible;

        }

        private void btn_Sobre_Click(object sender, EventArgs e)
        {
            FormSobre formsobre = new FormSobre();
            formsobre.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
