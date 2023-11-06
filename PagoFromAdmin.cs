using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EducarWeb.Clases;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;
using Font = iTextSharp.text.Font;

namespace EducarWeb
{
    public partial class PagoFromAdmin : Form
    {
        private MySqlConnection conexion;
        private int pagoId;
        private double pagoMonto;
        private int pagoCuotaId;
        private double cuotaMonto;
        private double pagoEstado;
        private double montoFinal;
        private string estadoFinal;

        private string nombre;

        public PagoFromAdmin(MySqlConnection conexion)
        {
            this.conexion = conexion;
            InitializeComponent();
            ActualizarDataGrid();
        }
        private void ActualizarDataGrid()
        {
            string query1 = "SELECT * FROM pago";
            using (conexion)
            {
                
                using (MySqlCommand command = new MySqlCommand(query1, conexion))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asigna los datos al DataGridView
                        dataGridView2.DataSource = dataTable;
                    }
                }
            }
            string query2 = "SELECT * FROM cuota";
            using (conexion)
            {
                
                using (MySqlCommand command = new MySqlCommand(query2, conexion))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asigna los datos al DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"ID: {pagoId}, Monto: {pagoMonto}, Cuota_ID: {pagoCuotaId}");
            ObtenerMontoCuotaPorId(pagoCuotaId);

            if (controlarEstadoPago() == "Pendiente")
            {
                modificarEstadoCuota();

                modificarMontoCuota();
                nombre = ObtenerNombrePadre();

                modificarEstadoPago();

                ActualizarDataGrid();

                
            }
            else
            {
                MessageBox.Show("Este pago ya ha sido confirmado previamente.");
            }
            FacturaA factura = new FacturaA();
            factura.GenerarFactura(7000, nombre);
        }

        private void modificarEstadoCuota()
        {
            montoFinal = cuotaMonto - pagoMonto;
            if (montoFinal <= 0)
            {
                estadoFinal = "Saldada";
                MessageBox.Show("La cuota esta saldada");
                
            }
            else
            {
                estadoFinal = "Pendiente";
                MessageBox.Show("La cuota aun esta pendiente");
            }
            string query = "UPDATE cuota SET estado = @estadoFinal WHERE id = @pagoCuotaId";
            using (conexion)
            {
                conexion.Open();
                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@estadoFinal", estadoFinal);
                    command.Parameters.AddWithValue("@pagoCuotaId", pagoCuotaId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Estado de cuota modificado correctamente" + montoFinal);
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }

        }

        private void modificarMontoCuota()
        {
            string query = "UPDATE cuota SET monto = @montoFinal WHERE id = @pagoCuotaId";
            using (conexion)
            {
                conexion.Open();
                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@montoFinal", montoFinal);
                    command.Parameters.AddWithValue("@pagoCuotaId", pagoCuotaId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("El monto pendiente de la cuota: "+ montoFinal);
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
            ActualizarDataGrid();
        }

        private double ObtenerMontoCuotaPorId(int cuotaId)
        {
            string query = "SELECT monto FROM cuota WHERE id = @cuotaId";
            using (conexion)
            {
                conexion.Open();
                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@cuotaId", cuotaId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cuotaMonto = Convert.ToDouble(reader["monto"]);
                        }
                    }
                }
            }
            return 0;
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView2.Rows[e.RowIndex].Cells["id"].Value != null)
                {
                    pagoId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["id"].Value);
                }

                if (dataGridView2.Rows[e.RowIndex].Cells["monto"].Value != null)
                {
                    pagoMonto = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["monto"].Value);
                }

                if (dataGridView2.Rows[e.RowIndex].Cells["cuota_id"].Value != null)
                {
                    pagoCuotaId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["cuota_id"].Value);
                }
            }
        }
        private string ObtenerNombrePadre()
        {
            using (conexion)
            {
                conexion.Open();

                string query = "SELECT p.nombre AS nombre_padre, p.apellido AS apellido_padre " +
                    "FROM cuota c " +
                    "JOIN persona_has_persona php ON c.persona_id = php.hijo_id " +
                    "JOIN persona p ON php.padre_id = p.id " +
                    "WHERE c.id = @pagoCuotaId;";

                using (MySqlCommand commando = new MySqlCommand(query, conexion))
                {
                    commando.Parameters.AddWithValue("@pagoCuotaId", pagoCuotaId);

                    using(MySqlDataReader reader = commando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nombrePadre = reader["nombre_padre"].ToString(); // Usar el alias
                            string apellidoPadre = reader["apellido_padre"].ToString(); // Usar el alias
                            return nombrePadre +" "+ apellidoPadre;
                        }
                    }
                }
            }
            return string.Empty;
        }
        
        private void modificarEstadoPago()
        {
            string query = "UPDATE pago SET estado = 'Confirmado' WHERE id = @pagoId";
            using (conexion)
            {
                conexion.Open();

                using(MySqlCommand command = new MySqlCommand( query, conexion))
                {
                    command.Parameters.AddWithValue("@pagoId", pagoId);
                    command.ExecuteNonQuery();
                }

            }
        }

        private string controlarEstadoPago()
        {
            string query = "SELECT estado FROM pago WHERE id = @pagoId";
            using (conexion)
            {
                conexion.Open();
                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@pagoId", pagoId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Asegúrate de llamar a Read() para avanzar al primer resultado.
                        {
                            string estado = reader.GetString(0);
                            return estado;
                        }
                        return string.Empty;
                    }
                }
            }
        }
    
        private void verPagosPendientes()
        {
            string query1 = "SELECT * FROM pago WHERE estado = 'Pendiente'";
            using (conexion)
            {

                using (MySqlCommand command = new MySqlCommand(query1, conexion))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asigna los datos al DataGridView
                        dataGridView2.DataSource = dataTable;
                    }
                }
            }
        }

        private void verCuotasPendientes()
        {
            string query1 = "SELECT * FROM cuota WHERE estado = 'Pendiente'";
            using (conexion)
            {

                using (MySqlCommand command = new MySqlCommand(query1, conexion))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asigna los datos al DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void verPagos()
        {
            string query1 = "SELECT * FROM pago";
            using (conexion)
            {

                using (MySqlCommand command = new MySqlCommand(query1, conexion))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asigna los datos al DataGridView
                        dataGridView2.DataSource = dataTable;
                    }
                }
            }
        }

        private void verCuotas()
        {
            string query1 = "SELECT * FROM cuota";
            using (conexion)
            {

                using (MySqlCommand command = new MySqlCommand(query1, conexion))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asigna los datos al DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            verPagosPendientes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            verPagos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            verCuotasPendientes();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            verCuotas();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            datagridviewPrinter.PrintCuotaAdmin(dataGridView1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            datagridviewPrinter.PrintPagoAdmin(dataGridView2);
        }

        private void PagoFromAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Obtener las fechas de inicio y fin del DateTimePicker
            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaFin = dateTimePicker2.Value;

            // Crear un objeto Document de iTextSharp
            Document doc = new Document();

            // Mostrar el cuadro de diálogo "Guardar como" para seleccionar la ubicación y el nombre del archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos PDF|*.pdf";
            saveFileDialog.Title = "Guardar archivo PDF";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Paragraph space = new Paragraph(" ");

                string pdfFileName = saveFileDialog.FileName;

                // Crear un objeto PdfWriter para escribir en el archivo PDF
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfFileName, FileMode.Create));

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
                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA, 18f);
                Paragraph title = new Paragraph("Planilla de Ingresos", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                // Agregar la fecha actual
                Font dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 12f);
                Paragraph date = new Paragraph("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"), dateFont);
                date.Alignment = Element.ALIGN_LEFT;
                doc.Add(date);
                doc.Add(space);
                doc.Add(space);
                // Crear una tabla para almacenar los datos del DataGridView
                float[] columnWidths = new float[dataGridView2.Columns.Count];
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    columnWidths[i] = 1f; // Establecer el ancho de cada columna a 1
                }
                PdfPTable table = new PdfPTable(columnWidths);
                table.WidthPercentage = 90; // Establecer el ancho de la tabla al 90% del ancho de la página

                // Añadir las cabeceras de las columnas al PDF
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    table.AddCell(new Phrase(dataGridView2.Columns[i].HeaderText));
                }

                // Recorrer las filas del DataGridView y agregarlas al PDF si cumplen con los criterios
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    DateTime fecha = Convert.ToDateTime(row.Cells["Fecha"].Value);
                    object estadoCellValue = row.Cells["Estado"].Value;

                    if (estadoCellValue != null)
                    {
                        string estado = estadoCellValue.ToString();

                        if (fecha >= fechaInicio && fecha <= fechaFin && estado == "Confirmado")
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                table.AddCell(new Phrase(cell.Value.ToString()));
                            }
                        }
                    }
                }

                doc.Add(table);
                doc.Close();

                MessageBox.Show("El archivo PDF se ha generado con éxito.");
            }


        }
    }
}
