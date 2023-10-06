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
    public partial class MateriaForm : Form
    {
        MySqlConnection conexion;
        public MateriaForm(MySqlConnection conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
        }

        private void btn_CrearMateria_Click(object sender, EventArgs e)
        {
            CrearMateriaForm cmf =  new CrearMateriaForm(conexion);
            cmf.ShowDialog();

        }

        private void btn_InscribirAlumno_Click(object sender, EventArgs e)
        {
            InscribirAlumnoForm lmf = new InscribirAlumnoForm(conexion);
            lmf.ShowDialog();
        }

        private void btn_ListarMaterias_Click(object sender, EventArgs e)
        {
            ListarMateriasForm lmf = new ListarMateriasForm(conexion);
            lmf.ShowDialog();
        }
    }
}
