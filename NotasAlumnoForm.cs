using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace EducarWeb
{
    public partial class NotasAlumnoForm : Form
    {
        MySqlConnection conexion;
        long idUsuario;
        string query = "SELECT n.calificacion, n.fecha, m.nombre AS nombre_materia, CONCAT(p.nombre, ' ', p.apellido) " +
            "AS nombre_alumno\r\nFROM nota n\r\nJOIN materia m ON n.materia_id = m.id\r\nJOIN persona p ON n.persona_id = p.id;\r\n";
        public NotasAlumnoForm(long idUsuario, MySqlConnection conexion)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.conexion = conexion;
            using (conexion)
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos PDF|*.pdf";
            saveFileDialog.Title = "Guardar PDF";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaPDF = saveFileDialog.FileName;

                Document doc = new Document(PageSize.A4.Rotate());
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaPDF, FileMode.Create));
                doc.Open();

                PdfPTable table = new PdfPTable(dataGridView1.ColumnCount);
                table.TotalWidth = 700f;
                float[] widths = new float[dataGridView1.ColumnCount];

                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    widths[i] = 2f;
                }

                table.SetWidths(widths);
                table.LockedWidth = true;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Value.ToString()));
                            table.AddCell(pdfCell);
                        }
                    }
                }

                doc.Add(table);
                doc.Close();
                writer.Close();

                MessageBox.Show("PDF generado con éxito.");
            }
        }
    }
}
