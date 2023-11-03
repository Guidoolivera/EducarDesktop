using iTextSharp.text.pdf.draw;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using Image = iTextSharp.text.Image;

namespace EducarWeb
{
    public partial class Cursos : Form
    {
        private MySqlConnection conexion;
        private readonly long idUsuario;
        private readonly string rolUsuario;

        public Cursos(MySqlConnection conexion, long idUsuario, string rolUsuario)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.idUsuario = idUsuario;
            this.rolUsuario = rolUsuario;
            CargarCursos();
        }

        private void CargarCursos()
        {
            string queryCursos =
                "SELECT id, nombre, descripcion, fecha_inicio, fecha_fin, aula " +
                "FROM curso";

            using (MySqlCommand cmd = new MySqlCommand(queryCursos, conexion))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvCursos.DataSource = dataTable;
                    dgvCursos.Columns["id"].Visible = false;
                }
            }
        }

        private void LimpiarCampos()
        {
            tbNombreCurso.Clear();
            tbDescripcionCurso.Clear();
            tbAulaCurso.Clear();
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;
        }

        private void btnCrearCurso_Click(object sender, EventArgs e)
        {
            string nombre = tbNombreCurso.Text;
            string descripcion = tbDescripcionCurso.Text;
            string aula = tbAulaCurso.Text;
            string fechaInicio = dtpFechaInicio.Value.ToString("yyyy-MM-dd");
            string fechaFin = dtpFechaFin.Value.ToString("yyyy-MM-dd");

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(aula))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            }

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            string queryInsercion = "INSERT INTO curso (nombre, descripcion, aula, fecha_inicio, fecha_fin) " +
                                    "VALUES (@nombre, @descripcion, @aula, @fechaInicio, @fechaFin)";

            using (MySqlCommand cmd = new MySqlCommand(queryInsercion, conexion))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@aula", aula);
                cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@fechaFin", fechaFin);

                try
                {
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Curso creado exitosamente.");
                        LimpiarCampos();
                        CargarCursos();
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el curso.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnImprimirPDF_Click(object sender, EventArgs e)
        {
            if (dgvCursos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un curso antes de generar el PDF.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos PDF|*.pdf";
            saveFileDialog.Title = "Guardar PDF";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaPDF = saveFileDialog.FileName;

                Document doc = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaPDF, FileMode.Create));


                // Obtener la información del curso seleccionado
                long cursoId = Convert.ToInt64(dgvCursos.SelectedRows[0].Cells["id"].Value);

                string nombreCurso = ObtenerNombreCurso(cursoId);
                string descripcionCurso = dgvCursos.SelectedRows[0].Cells["descripcion"].Value.ToString();
                string aulaCurso = dgvCursos.SelectedRows[0].Cells["aula"].Value.ToString();

                // Crear una instancia de CustomPdfPageEvent para el footer
                CustomPdfPageEvent eventHelper = new CustomPdfPageEvent(nombreCurso);
                writer.PageEvent = eventHelper;


                // Abre el documento para escribir
                doc.Open();

                // Agregar el logo de la institución
                Image img = Image.GetInstance("C:\\Users\\Guido\\Documents\\GitHub\\EducarDesktop\\img\\logo.jpg.png"); // Cambia la ruta al logo
                img.ScaleAbsolute(80f, 80f); // Ajusta el tamaño según tus necesidades
                img.SetAbsolutePosition(40, PageSize.A4.Height - 110); // Posición en la página
                doc.Add(img);


                doc.Add(new Paragraph("\n\n\n\n"));
                doc.Add(new Paragraph("INFORMACION DEL CURSO"));
                doc.Add(new Paragraph($"Descripción: {descripcionCurso}"));
                doc.Add(new Paragraph($"Aula: {aulaCurso}"));
                doc.Add(new Paragraph("\n\n"));

                // Agregar división en el extremo superior derecho
                PdfContentByte cb = writer.DirectContent;
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetColorFill(BaseColor.BLACK);
                cb.SetFontAndSize(bf, 12);

                // Define la posición de la división

                /*
                float dividerX = 500;  // Ajusta esto para la posición horizontal
                float dividerY = 800;  // Ajusta esto para la posición vertical

                cb.BeginText();
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "División", dividerX, dividerY, 0);
                cb.EndText();
                */

                // Agregar una tabla para el listado de alumnos
                PdfPTable table = new PdfPTable(3); // 3 columnas para id, apellido, nombre
                table.TotalWidth = 500f; // Ancho de la tabla
                float[] columnWidths = { 1f, 2f, 2f }; // Ancho de cada columna

                table.SetWidths(columnWidths);

                // Agregar encabezados de columna
                table.AddCell(new PdfPCell(new Phrase("LEGAJO")));
                table.AddCell(new PdfPCell(new Phrase("APELLIDO")));
                table.AddCell(new PdfPCell(new Phrase("NOMBRE")));

                // Obtener la lista de alumnos
                HashSet<string> alumnosInscritos = ObtenerAlumnosInscritos(cursoId);

                foreach (string alumno in alumnosInscritos)
                {
                    string[] alumnoData = alumno.Split(';'); // Suponiendo que los datos están separados por punto y coma

                    // Agregar datos de alumno a la tabla
                    table.AddCell(new PdfPCell(new Phrase(alumnoData[0]))); // ID
                    table.AddCell(new PdfPCell(new Phrase(alumnoData[1]))); // Apellido
                    table.AddCell(new PdfPCell(new Phrase(alumnoData[2]))); // Nombre
                }

                // Agregar la tabla al documento
                doc.Add(table);

                // Calcular el total de alumnos
                doc.Add(new Paragraph("\n\n"));
                int totalAlumnos = alumnosInscritos.Count;

                // Agregar el total al final del documento
                doc.Add(new Paragraph($"Total de Alumnos: {totalAlumnos}"));

                doc.Close();
                writer.Close();

                MessageBox.Show("PDF generado con éxito.");
            }
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

        private HashSet<string> ObtenerAlumnosInscritos(long cursoId)
        {
            HashSet<string> alumnosInscritos = new HashSet<string>();

            // Consulta para obtener los ID de las materias relacionadas con el curso
            string queryMateriasCurso = "SELECT id FROM materia WHERE curso_id = @cursoId";

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            List<long> materiasIds = new List<long>();
            using (MySqlCommand cmdMateriasCurso = new MySqlCommand(queryMateriasCurso, conexion))
            {
                cmdMateriasCurso.Parameters.AddWithValue("@cursoId", cursoId);

                using (MySqlDataReader readerMateriasCurso = cmdMateriasCurso.ExecuteReader())
                {
                    while (readerMateriasCurso.Read())
                    {
                        long materiaId = readerMateriasCurso.GetInt64("id");
                        materiasIds.Add(materiaId);
                    }
                }
            }

            // Consulta para obtener los nombres de los alumnos inscritos en las materias
            string queryAlumnosInscritos = "SELECT CONCAT(p.id, ';', p.apellido, ';', p.nombre) AS alumno_data " +
                "FROM persona p " +
                "INNER JOIN persona_has_materia pm ON p.id = pm.persona_id " +
                "WHERE pm.materia_id = @materiaId";

            foreach (long materiaId in materiasIds)
            {
                using (MySqlCommand cmdAlumnosInscritos = new MySqlCommand(queryAlumnosInscritos, conexion))
                {
                    cmdAlumnosInscritos.Parameters.AddWithValue("@materiaId", materiaId);

                    using (MySqlDataReader readerAlumnosInscritos = cmdAlumnosInscritos.ExecuteReader())
                    {
                        while (readerAlumnosInscritos.Read())
                        {
                            string alumnoData = readerAlumnosInscritos.GetString("alumno_data");
                            alumnosInscritos.Add(alumnoData);
                        }
                    }
                }
            }

            return alumnosInscritos;
        }
    }
}