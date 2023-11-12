using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image = iTextSharp.text.Image;

namespace EducarWeb
{
    public partial class ListarMateriasForm : Form
    {
        private MySqlConnection conexion;
        private readonly long idUsuario;
        private readonly string rolUsuario;
        private SaveFileDialog saveFileDialog;
        //readonly string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "logo.png");
        public ListarMateriasForm(MySqlConnection conexion, long idUsuario, string rolUsuario)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.idUsuario = idUsuario;
            this.rolUsuario = rolUsuario;
            CargarMaterias();
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos PDF|*.pdf";
            saveFileDialog.Title = "Guardar PDF";

            // Verifica el rol del usuario y realiza las acciones correspondientes
            if (rolUsuario == "Alumno")
            {
                // Si el usuario es un alumno, oculta los controles y ajusta el tamaño del formulario
                listBoxAlumnos.Hide();
                lblAlumnosInscritos.Hide();
                btnGenerarPDFs.Hide();

                // Opcional: Ajusta el tamaño del formulario
                this.Size = new Size(550, 310); // Ajusta el tamaño según tus necesidades
            }
        }


        private void CargarMaterias()
        {
            try
            {
                string queryMaterias =
                    "SELECT m.id, m.nombre AS materia, p.nombre AS profesor, " +
                    "GROUP_CONCAT(pAlumno.nombre SEPARATOR ', ') AS alumnos, " +
                    "m.horarios, " +
                    "c.nombre AS nombre_curso, " +
                    "COUNT(phm.materia_id) AS cantidad_inscritos " +
                    "FROM materia m " +
                    "INNER JOIN persona p ON m.profesor_id = p.id " +
                    "LEFT JOIN persona_has_materia phm ON m.id = phm.materia_id " +
                    "LEFT JOIN persona pAlumno ON phm.persona_id = pAlumno.id " +
                    "INNER JOIN curso c ON m.curso_id = c.id ";

                if (rolUsuario == "Profesor")
                {
                    queryMaterias += "WHERE p.id = @idUsuario ";
                }
                else if (rolUsuario == "Padre")
                {
                    // Si el usuario es un Padre, cargar las materias de sus hijos
                    CargarMateriasParaPadre();
                    return;
                }

                queryMaterias += "GROUP BY m.id, m.nombre, p.nombre, m.horarios, c.nombre";

                using (MySqlCommand cmd = new MySqlCommand(queryMaterias, conexion))
                {
                    if (rolUsuario == "Profesor")
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    }

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvMaterias.DataSource = dataTable;

                        dgvMaterias.Columns["id"].Visible = true;
                        dgvMaterias.Columns["id"].HeaderText = "ID";
                        dgvMaterias.Columns["materia"].HeaderText = "Materia";
                        dgvMaterias.Columns["profesor"].HeaderText = "Profesor";
                        dgvMaterias.Columns["horarios"].HeaderText = "Horarios";
                        dgvMaterias.Columns["nombre_curso"].HeaderText = "Curso";
                        dgvMaterias.Columns["alumnos"].Visible = false;
                        dgvMaterias.Columns["cantidad_inscritos"].HeaderText = "Inscritos";

                        dgvMaterias.SelectionChanged += dgvMaterias_SelectionChanged;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las materias: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Función para cargar las materias de los hijos de un padre
        private void CargarMateriasParaPadre()
        {
            try
            {
                string queryHijos =
                    "SELECT hijo_id " +
                    "FROM persona_has_persona " +
                    "WHERE padre_id = @idUsuario";

                using (MySqlCommand cmdHijos = new MySqlCommand(queryHijos, conexion))
                {
                    cmdHijos.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (MySqlDataReader readerHijos = cmdHijos.ExecuteReader())
                    {
                        while (readerHijos.Read())
                        {
                            long idHijo = readerHijos.GetInt64("hijo_id");
                            string queryMateriasHijo =
                                "SELECT m.id, m.nombre AS materia, p.nombre AS profesor, " +
                                "m.horarios, " +
                                "c.nombre AS nombre_curso, " +
                                "COUNT(phm.materia_id) AS cantidad_inscritos " +
                                "FROM materia m " +
                                "INNER JOIN persona p ON m.profesor_id = p.id " +
                                "INNER JOIN persona_has_materia phm ON m.id = phm.materia_id " +
                                "INNER JOIN curso c ON m.curso_id = c.id " +
                                "WHERE phm.persona_id = @idHijo " +
                                "GROUP BY m.id, m.nombre, p.nombre, m.horarios, c.nombre";

                            using (MySqlCommand cmdMateriasHijo = new MySqlCommand(queryMateriasHijo, conexion))
                            {
                                cmdMateriasHijo.Parameters.AddWithValue("@idHijo", idHijo);
                                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmdMateriasHijo))
                                {
                                    DataTable dataTable = new DataTable();
                                    adapter.Fill(dataTable);
                                    dgvMaterias.DataSource = dataTable;

                                    dgvMaterias.Columns["id"].Visible = true;
                                    dgvMaterias.Columns["id"].HeaderText = "ID";
                                    dgvMaterias.Columns["materia"].HeaderText = "Materia";
                                    dgvMaterias.Columns["profesor"].HeaderText = "Profesor";
                                    dgvMaterias.Columns["horarios"].HeaderText = "Horarios";
                                    dgvMaterias.Columns["nombre_curso"].HeaderText = "Curso";
                                    dgvMaterias.Columns["alumnos"].Visible = false;
                                    dgvMaterias.Columns["cantidad_inscritos"].HeaderText = "Inscritos";

                                    dgvMaterias.SelectionChanged += dgvMaterias_SelectionChanged;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las materias de los hijos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dgvMaterias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMaterias.SelectedRows.Count > 0)
            {
                int idMateria = Convert.ToInt32(dgvMaterias.SelectedRows[0].Cells["id"].Value);
                string materiaSeleccionada = dgvMaterias.SelectedRows[0].Cells["materia"].Value.ToString();

                try
                {
                    // Consulta para cargar la lista de alumnos inscritos con nombre y apellido
                    string queryAlumnosInscritos =
                        "SELECT CONCAT(p.apellido, ', ', p.nombre) AS nombre_completo " +
                        "FROM persona p " +
                        "INNER JOIN persona_has_materia phm ON p.id = phm.persona_id " +
                        "WHERE phm.materia_id = @idMateria";

                    using (MySqlCommand cmd = new MySqlCommand(queryAlumnosInscritos, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idMateria", idMateria);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Mostrar la lista de alumnos inscritos en el ListBox
                            listBoxAlumnos.DataSource = dataTable;
                            listBoxAlumnos.DisplayMember = "nombre_completo";

                            // Actualizar el título del ListBox
                            lblAlumnosInscritos.Text = $"Alumnos Inscritos en {materiaSeleccionada}:";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la lista de alumnos inscritos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGenerarPDFs_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona al menos una materia para generar los PDFs.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataGridViewRow selectedRow in dgvMaterias.SelectedRows)
                    {
                        long idMateria = Convert.ToInt64(selectedRow.Cells["id"].Value);
                        string nombreMateria = selectedRow.Cells["materia"].Value.ToString();
                        string nombreProfesor = selectedRow.Cells["profesor"].Value.ToString();
                        string horarios = selectedRow.Cells["horarios"].Value.ToString();
                        string nombreCurso = selectedRow.Cells["nombre_curso"].Value.ToString();

                        Document doc = new Document(PageSize.A4);
                        string rutaPDF = saveFileDialog.FileName;
                        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaPDF, FileMode.Create));

                        // Abre el documento para escribir
                        doc.Open();

                        // Agregar el logo de la institución
                        Image img = Image.GetInstance("img\\logo.png"); // Cambia la ruta al logo
                        img.ScaleAbsolute(80f, 80f); // Ajusta el tamaño según tus necesidades
                        img.SetAbsolutePosition(40, PageSize.A4.Height - 110); // Posición en la página
                        doc.Add(img);

                        CustomPdfPageEvent eventHelper = new CustomPdfPageEvent(nombreCurso);
                        writer.PageEvent = eventHelper;

                        doc.Add(new Paragraph("\n\n\n\n"));
                        doc.Add(new Paragraph("INFORMACION DE LA MATERIA"));
                        doc.Add(new Paragraph("Nombre de la Materia: " + nombreMateria));
                        doc.Add(new Paragraph("Nombre del Profesor: " + nombreProfesor));
                        doc.Add(new Paragraph("Horarios: " + horarios));
                        doc.Add(new Paragraph("\n\n"));

                        PdfContentByte cb = writer.DirectContent;
                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.SetFontAndSize(bf, 12);

                        string queryAlumnosInscritos =
                            "SELECT p.id, p.apellido, p.nombre " +
                            "FROM persona p " +
                            "INNER JOIN persona_has_materia phm ON p.id = phm.persona_id " +
                            "WHERE phm.materia_id = @idMateria " +
                            "ORDER BY p.apellido, p.nombre";

                        using (MySqlCommand cmd = new MySqlCommand(queryAlumnosInscritos, conexion))
                        {
                            cmd.Parameters.AddWithValue("@idMateria", idMateria);

                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                PdfPTable table = new PdfPTable(3);
                                table.TotalWidth = 500f;
                                float[] columnWidths = { 1f, 2f, 2f };
                                table.SetWidths(columnWidths);

                                table.AddCell(new PdfPCell(new Phrase("ID")));
                                table.AddCell(new PdfPCell(new Phrase("Apellido")));
                                table.AddCell(new PdfPCell(new Phrase("Nombre")));

                                foreach (DataRow row in dataTable.Rows)
                                {
                                    table.AddCell(new PdfPCell(new Phrase(row["id"].ToString())));
                                    table.AddCell(new PdfPCell(new Phrase(row["apellido"].ToString())));
                                    table.AddCell(new PdfPCell(new Phrase(row["nombre"].ToString())));
                                }

                                doc.Add(table);

                                doc.Add(new Paragraph("\n\n"));

                                int totalAlumnos = dataTable.Rows.Count;

                                doc.Add(new Paragraph($"Total de Alumnos: {totalAlumnos}"));
                            }
                        }

                        doc.Close();
                        writer.Close();
                    }

                    MessageBox.Show("PDFs generados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar los PDFs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
        private long ObtenerIdCursoParaMateria(long idMateria)
        {
            long idCurso = -1;
            string query = "SELECT curso_id FROM materia WHERE id = @idMateria";

            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@idMateria", idMateria);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        idCurso = reader.GetInt64("curso_id");
                    }
                }
            }

            return idCurso;
        }

        private string ObtenerNombreCurso(long cursoId)
        {
            string nombreCurso = string.Empty;
            string query = "SELECT nombre FROM curso WHERE id = @cursoId";

            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@cursoId", cursoId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nombreCurso = reader.GetString("nombre");
                    }
                }
            }

            return nombreCurso;
        }
        */

    }

}
