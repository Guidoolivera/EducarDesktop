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
        public MainForm(string username, bool esAdmin, MySqlConnection conexion)
        {
            InitializeComponent();
            lbl_bienvenido.Text = "Bienvenido, " + username;
            this.esAdmin = esAdmin;
            this.conexion = conexion; 
        }

        private void btn_Materias_Click(object sender, EventArgs e)
        {
            MateriaForm materiaForm = new MateriaForm(conexion); // Pasa la conexión
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
    }
}
