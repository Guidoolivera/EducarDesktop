﻿using iTextSharp.text.pdf.draw;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace EducarWeb
{
    public partial class GestionCursosForm : Form
    {
        private MySqlConnection conexion;

        public GestionCursosForm(MySqlConnection conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
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

                Document doc = new Document(PageSize.A4.Rotate());
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaPDF, FileMode.Create));

                // Crear una instancia de CustomPdfPageEvent para el footer
                CustomPdfPageEvent eventHelper = new CustomPdfPageEvent();
                writer.PageEvent = eventHelper;

                doc.Open();

                // Obtener la información del curso seleccionado
                long cursoId = Convert.ToInt64(dgvCursos.SelectedRows[0].Cells["id"].Value);
                string nombreCurso = dgvCursos.SelectedRows[0].Cells["nombre"].Value.ToString();
                string descripcionCurso = dgvCursos.SelectedRows[0].Cells["descripcion"].Value.ToString();
                string aulaCurso = dgvCursos.SelectedRows[0].Cells["aula"].Value.ToString();

                // Agregar información del curso al PDF
                doc.Add(new Paragraph("Información del Curso:"));
                doc.Add(new Paragraph($"Nombre: {nombreCurso}"));
                doc.Add(new Paragraph($"Descripción: {descripcionCurso}"));
                doc.Add(new Paragraph($"Aula: {aulaCurso}"));

                // Agregar división en el extremo superior derecho
                PdfContentByte cb = writer.DirectContent;
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetColorFill(BaseColor.BLACK);
                cb.SetFontAndSize(bf, 12);

                // Define la posición de la división
                float dividerX = 500;  // Ajusta esto para la posición horizontal
                float dividerY = 800;  // Ajusta esto para la posición vertical

                cb.BeginText();
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "División", dividerX, dividerY, 0);
                cb.EndText();

                // Agregar una tabla para el listado de alumnos
                PdfPTable table = new PdfPTable(3); // 3 columnas para id, apellido, nombre
                table.TotalWidth = 500f; // Ancho de la tabla
                float[] columnWidths = { 1f, 2f, 2f }; // Ancho de cada columna

                table.SetWidths(columnWidths);

                // Agregar encabezados de columna
                table.AddCell(new PdfPCell(new Phrase("ID")));
                table.AddCell(new PdfPCell(new Phrase("Apellido")));
                table.AddCell(new PdfPCell(new Phrase("Nombre")));

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
                int totalAlumnos = alumnosInscritos.Count;

                // Agregar el total al final del documento
                doc.Add(new Paragraph($"Total de Alumnos: {totalAlumnos}"));

                doc.Close();
                writer.Close();

                MessageBox.Show("PDF generado con éxito.");
            }
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