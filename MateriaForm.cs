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
        long idUsuario;
        string rolUsuario;

        public MateriaForm(MySqlConnection conexion, long idUsuario, string rolUsuario)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.idUsuario = idUsuario;
            this.rolUsuario = rolUsuario;

            // Llamar a un método para configurar la visibilidad de los botones según el rol
            ConfigurarVisibilidadBotones();
        }

        private void ConfigurarVisibilidadBotones()
        {
            if (rolUsuario == "Administrador")
            {
                // El administrador tiene acceso a todo, no es necesario ocultar ningún botón.
            }
            else if (rolUsuario == "Directivo" || rolUsuario == "Profesor")
            {
                // Ocultar los botones para directivos y profesores
                btn_CrearMateria.Visible = false;
                btn_GestionarInscripciones.Visible = false;
                btn_InscribirAlumno.Visible = false;
            }
            else if (rolUsuario == "Alumno")
            {
                // Ocultar los botones para alumnos
                btn_CrearMateria.Visible = false;
                btn_GestionarInscripciones.Visible = false;
                btn_Cursos.Visible = false;
            }
        }

        private void btn_CrearMateria_Click(object sender, EventArgs e)
        {
            CrearMateriaForm cmf = new CrearMateriaForm(conexion, idUsuario, rolUsuario);
            cmf.ShowDialog();
        }

        private void btn_InscribirAlumno_Click(object sender, EventArgs e)
        {
            SolicitarInscripcionForm sif = new SolicitarInscripcionForm(conexion, idUsuario, rolUsuario);
            sif.ShowDialog();
        }

        private void btn_ListarMaterias_Click(object sender, EventArgs e)
        {
            ListarMateriasForm lmf = new ListarMateriasForm(conexion, idUsuario, rolUsuario);
            lmf.ShowDialog();
        }

        private void btn_GestionarInscripciones_Click(object sender, EventArgs e)
        {
            SolicitudesInscripcionForm slif = new SolicitudesInscripcionForm(conexion, idUsuario, rolUsuario);
            slif.ShowDialog();
        }

        private void btn_Cursos_Click(object sender, EventArgs e)
        {
            GestionCursosForm gcf = new GestionCursosForm(conexion, idUsuario, rolUsuario);
            gcf.ShowDialog();
        }
    }
}