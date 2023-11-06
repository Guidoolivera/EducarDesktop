using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Windows.Forms;

namespace EducarWeb.Clases
{
    static class datagridviewPrinter
    {
        public static void PrintCuota(DataGridView dataGridView, string alumnoNombre)
        {
            if (dataGridView != null && dataGridView.Rows.Count > 0)
            {
                // Configura un cuadro de diálogo para seleccionar la ubicación del archivo PDF
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos PDF|*.pdf";
                saveFileDialog.Title = "Guardar como PDF";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    Paragraph space = new Paragraph(" ", new Font(Font.FontFamily.HELVETICA, 12f));
                    space.Alignment = Element.ALIGN_LEFT;

                    string filePath = saveFileDialog.FileName;

                    // Crea un documento PDF
                    Document doc = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

                    // Abre el documento para escribir
                    doc.Open();

                    doc.Add(space);
                    doc.Add(space);
                    doc.Add(space);
                    doc.Add(space);

                    // Agregar logo (ajusta las coordenadas según tus necesidades)
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("img/logo.png");
                    logo.ScaleAbsolute(100f, 80f);
                    logo.SetAbsolutePosition(50, 730); // Cambia el valor de 150 según tus necesidades
                    doc.Add(logo);

                    // Agregar "Planilla de Cuotas" y la fecha actual
                    Paragraph title = new Paragraph("Planilla de Cuotas", new Font(Font.FontFamily.HELVETICA, 18f, Font.BOLD));
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);

                    // Agregar la fecha actual
                    Paragraph date = new Paragraph("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"), new Font(Font.FontFamily.HELVETICA, 12f));
                    date.Alignment = Element.ALIGN_LEFT;
                    doc.Add(date);

                    // Agregar el nombre del alumno (debe ser proporcionado como parámetro)
                    Paragraph studentName = new Paragraph("Nombre del Alumno: " + alumnoNombre, new Font(Font.FontFamily.HELVETICA, 12f));
                    studentName.Alignment = Element.ALIGN_LEFT;
                    doc.Add(studentName);

                    
                    doc.Add(space);

                    // Crear una tabla en el documento PDF
                    PdfPTable table = new PdfPTable(dataGridView.ColumnCount);
                    table.DefaultCell.Padding = 3;
                    table.WidthPercentage = 100;
                    table.HorizontalAlignment = 0;

                    // Agregar encabezados de columna
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        cell.BackgroundColor = new BaseColor(240, 240, 240);
                        table.AddCell(cell);
                    }

                    // Agregar filas y celdas de datos
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.IsNewRow) continue; // Salta las filas en blanco
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(cell.Value != null ? cell.Value.ToString() : string.Empty);
                        }
                    }

                    // Agregar la tabla al documento
                    doc.Add(table);

                    // Cerrar el documento
                    doc.Close();

                    // Cerrar el escritor del PDF
                    writer.Close();

                    MessageBox.Show("PDF guardado exitosamente en " + filePath, "PDF Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No hay datos en el DataGridView para procesar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void PrintCuotaAdmin(DataGridView dataGridView)
        {
            if (dataGridView != null && dataGridView.Rows.Count > 0)
            {
                // Configura un cuadro de diálogo para seleccionar la ubicación del archivo PDF
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos PDF|*.pdf";
                saveFileDialog.Title = "Guardar como PDF";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    Paragraph space = new Paragraph(" ", new Font(Font.FontFamily.HELVETICA, 12f));
                    space.Alignment = Element.ALIGN_LEFT;

                    string filePath = saveFileDialog.FileName;

                    // Crea un documento PDF
                    Document doc = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

                    // Abre el documento para escribir
                    doc.Open();

                    doc.Add(space);
                    doc.Add(space);
                    doc.Add(space);
                    doc.Add(space);

                    // Agregar logo (ajusta las coordenadas según tus necesidades)
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("img/logo.png");
                    logo.ScaleAbsolute(100f, 80f);
                    logo.SetAbsolutePosition(50, 730); // Cambia el valor de 150 según tus necesidades
                    doc.Add(logo);

                    // Agregar "Planilla de Cuotas" y la fecha actual
                    Paragraph title = new Paragraph("Planilla de Cuotas", new Font(Font.FontFamily.HELVETICA, 18f, Font.BOLD));
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);

                    // Agregar la fecha actual
                    Paragraph date = new Paragraph("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"), new Font(Font.FontFamily.HELVETICA, 12f));
                    date.Alignment = Element.ALIGN_LEFT;
                    doc.Add(date);

                    // Agregar el nombre del alumno (debe ser proporcionado como parámetro)
                    


                    doc.Add(space);

                    // Crear una tabla en el documento PDF
                    PdfPTable table = new PdfPTable(dataGridView.ColumnCount);
                    table.DefaultCell.Padding = 3;
                    table.WidthPercentage = 100;
                    table.HorizontalAlignment = 0;

                    // Agregar encabezados de columna
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        cell.BackgroundColor = new BaseColor(240, 240, 240);
                        table.AddCell(cell);
                    }

                    // Agregar filas y celdas de datos
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.IsNewRow) continue; // Salta las filas en blanco
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(cell.Value != null ? cell.Value.ToString() : string.Empty);
                        }
                    }

                    // Agregar la tabla al documento
                    doc.Add(table);

                    // Cerrar el documento
                    doc.Close();

                    // Cerrar el escritor del PDF
                    writer.Close();

                    MessageBox.Show("PDF guardado exitosamente en " + filePath, "PDF Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No hay datos en el DataGridView para procesar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void PrintPagoAdmin(DataGridView dataGridView)
        {
            if (dataGridView != null && dataGridView.Rows.Count > 0)
            {
                // Configura un cuadro de diálogo para seleccionar la ubicación del archivo PDF
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos PDF|*.pdf";
                saveFileDialog.Title = "Guardar como PDF";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    Paragraph space = new Paragraph(" ", new Font(Font.FontFamily.HELVETICA, 12f));
                    space.Alignment = Element.ALIGN_LEFT;

                    string filePath = saveFileDialog.FileName;

                    // Crea un documento PDF
                    Document doc = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

                    // Abre el documento para escribir
                    doc.Open();

                    doc.Add(space);
                    doc.Add(space);
                    doc.Add(space);
                    doc.Add(space);

                    // Agregar logo (ajusta las coordenadas según tus necesidades)
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("img/logo.png");
                    logo.ScaleAbsolute(100f, 80f);
                    logo.SetAbsolutePosition(50, 730); // Cambia el valor de 150 según tus necesidades
                    doc.Add(logo);

                    // Agregar "Planilla de Cuotas" y la fecha actual
                    Paragraph title = new Paragraph("Planilla de Pagos", new Font(Font.FontFamily.HELVETICA, 18f, Font.BOLD));
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);

                    // Agregar la fecha actual
                    Paragraph date = new Paragraph("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"), new Font(Font.FontFamily.HELVETICA, 12f));
                    date.Alignment = Element.ALIGN_LEFT;
                    doc.Add(date);

                    // Agregar el nombre del alumno (debe ser proporcionado como parámetro)



                    doc.Add(space);

                    // Crear una tabla en el documento PDF
                    PdfPTable table = new PdfPTable(dataGridView.ColumnCount);
                    table.DefaultCell.Padding = 3;
                    table.WidthPercentage = 100;
                    table.HorizontalAlignment = 0;

                    // Agregar encabezados de columna
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        cell.BackgroundColor = new BaseColor(240, 240, 240);
                        table.AddCell(cell);
                    }

                    // Agregar filas y celdas de datos
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.IsNewRow) continue; // Salta las filas en blanco
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(cell.Value != null ? cell.Value.ToString() : string.Empty);
                        }
                    }

                    // Agregar la tabla al documento
                    doc.Add(table);

                    // Cerrar el documento
                    doc.Close();

                    // Cerrar el escritor del PDF
                    writer.Close();

                    MessageBox.Show("PDF guardado exitosamente en " + filePath, "PDF Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No hay datos en el DataGridView para procesar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void PrintBoletin(DataGridView dataGridView, string alumnoNombre)
        {
            if (dataGridView != null && dataGridView.Rows.Count > 0)
            {
                // Configura un cuadro de diálogo para seleccionar la ubicación del archivo PDF
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos PDF|*.pdf";
                saveFileDialog.Title = "Guardar como PDF";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    Paragraph space = new Paragraph(" ", new Font(Font.FontFamily.HELVETICA, 12f));
                    space.Alignment = Element.ALIGN_LEFT;

                    string filePath = saveFileDialog.FileName;

                    // Crea un documento PDF
                    Document doc = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

                    // Abre el documento para escribir
                    doc.Open();

                    doc.Add(space);
                    doc.Add(space);
                    doc.Add(space);
                    doc.Add(space);

                    // Agregar logo (ajusta las coordenadas según tus necesidades)
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("img/logo.png");
                    logo.ScaleAbsolute(100f, 80f);
                    logo.SetAbsolutePosition(50, 730); // Cambia el valor de 150 según tus necesidades
                    doc.Add(logo);

                    // Agregar "Planilla de Cuotas" y la fecha actual
                    Paragraph title = new Paragraph("Boletin", new Font(Font.FontFamily.HELVETICA, 18f, Font.BOLD));
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);

                    // Agregar la fecha actual
                    Paragraph date = new Paragraph("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"), new Font(Font.FontFamily.HELVETICA, 12f));
                    date.Alignment = Element.ALIGN_LEFT;
                    doc.Add(date);

                    // Agregar el nombre del alumno (debe ser proporcionado como parámetro)
                    Paragraph studentName = new Paragraph("Nombre del Alumno: " + alumnoNombre, new Font(Font.FontFamily.HELVETICA, 12f));
                    studentName.Alignment = Element.ALIGN_LEFT;
                    doc.Add(studentName);


                    doc.Add(space);

                    // Crear una tabla en el documento PDF
                    PdfPTable table = new PdfPTable(dataGridView.ColumnCount);
                    table.DefaultCell.Padding = 3;
                    table.WidthPercentage = 100;
                    table.HorizontalAlignment = 0;

                    // Agregar encabezados de columna
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        cell.BackgroundColor = new BaseColor(240, 240, 240);
                        table.AddCell(cell);
                    }

                    // Agregar filas y celdas de datos
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.IsNewRow) continue; // Salta las filas en blanco
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(cell.Value != null ? cell.Value.ToString() : string.Empty);
                        }
                    }

                    // Agregar la tabla al documento
                    doc.Add(table);

                    // Cerrar el documento
                    doc.Close();

                    // Cerrar el escritor del PDF
                    writer.Close();

                    MessageBox.Show("PDF guardado exitosamente en " + filePath, "PDF Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No hay datos en el DataGridView para procesar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
