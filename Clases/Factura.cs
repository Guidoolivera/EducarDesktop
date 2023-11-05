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
    internal class FacturaA
    {
        public void GenerarFactura()
        {
            Document doc = new Document();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos PDF|*.pdf";
            saveFileDialog.Title = "Guardar Factura A";
            saveFileDialog.FileName = "FacturaA.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string outputPath = saveFileDialog.FileName;
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(outputPath, FileMode.Create));

                doc.Open();

                // RECTANGULOS
                PdfContentByte cb = writer.DirectContent;
                cb.Rectangle(20, 800, 550, 20);
                cb.Stroke();

                cb.Rectangle(20, 655, 275, 145);
                cb.Stroke();
                cb.Rectangle(295, 655, 275, 145);
                cb.Stroke();

                cb.Rectangle(20, 555, 550, 100);
                cb.Stroke();


                cb.SetColorFill(BaseColor.WHITE);
                cb.Rectangle(274, 760, 40, 40);
                cb.Fill();
                cb.SetColorFill(BaseColor.WHITE);
                cb.Rectangle(274, 760, 40, 40);
                cb.Stroke();

                //rectangulo footer
                cb.Rectangle(20, 100, 550, 100);
                cb.Stroke();








                //ORIGINAL
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetColorFill(BaseColor.BLACK);
                cb.SetFontAndSize(bf, 14);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_LEFT, "ORIGINAL", 260, 805, 0);
                cb.EndText();

                //FACTURA
                BaseFont bf2 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetColorFill(BaseColor.BLACK);
                cb.SetFontAndSize(bf2, 16);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_LEFT, "FACTURA", 330, 775, 0);
                cb.EndText();

                //A
                cb.SetColorFill(BaseColor.BLACK);
                cb.SetFontAndSize(bf2, 24);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_LEFT, "A", 287, 775, 0);
                cb.EndText();



                //DATOS DE LA EMPRESA

                //Razon Social: Educar Para Trasformar
                BaseFont bf3 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_LEFT, "Razon Social: Educar Para Trasformar", 30, 700, 0);
                cb.EndText();

                //Domicilio Comercial
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_LEFT, "Domicilio Comercial: French 666, Resistencia Chaco", 30, 680, 0);
                cb.EndText();

                //Condicion frente al IVA
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_LEFT, "Condicion frente al IVA: Responsable Inscripto", 30, 660, 0);
                cb.EndText();


                //DATOS DE CLIENTE

                //Punto de Venta
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_LEFT, "Punto de Venta: 001", 305, 740, 0);
                cb.EndText();

                //Punto de Venta
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_LEFT, "Comp. Nro 0000X", 425, 740, 0);
                cb.EndText();

                //Fecha de Emision. PONER VARIABLE DE FECHA DE PAGO!!!
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_LEFT, "Fecha de Emision: 31/3/00", 305, 720, 0);
                cb.EndText();

                //CUIT
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_LEFT, "CUIT: XXXXXXXXXX", 305, 690, 0);
                cb.EndText();

                //INGRESOS BRUTOS
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_LEFT, "Ingresos Brutos: XXXXXXXXXX", 305, 680, 0);
                cb.EndText();

                //Fecha de Inicio de Actividades 20, 655
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_LEFT, "Fecha de Inicio de Actividades: 9/11/01", 305, 670, 0);
                cb.EndText();

                //CUIT 20, 655
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_LEFT, "CUIT 30710443943", 30, 645, 0);
                cb.EndText();

                //Condicion Frente al IVA
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_LEFT, "Condicion Frente al IVA: Responsable Inscripto", 30, 625, 0);
                cb.EndText();

                //Condicion de Venta
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_LEFT, "Condicion de Venta 15 dias Fecha Factura", 30, 605, 0);
                cb.EndText();

                //Nombre y Apellido / Razon Social
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_LEFT, "Nombre y Apellido / Razon Social:", 180, 645, 0);
                cb.EndText();

                //Domicilio: 
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_LEFT, "Domicilio:", 300, 625, 0);
                cb.EndText();

                //Nro. Remito
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_LEFT, "Nro. Remito 00003628", 270, 605, 0);
                cb.EndText();


                //FOOTER

                //Subtotal
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_RIGHT, "Subtotal: $       00000", 540, 180, 0);
                cb.EndText();
                //IVA
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_RIGHT, "IVA 21%: $       00000", 540, 160, 0);
                cb.EndText();
                //Importe Otros Tributos
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_RIGHT, "Importe Otros Tributos: $       00000", 540, 140, 0);
                cb.EndText();
                //Importe Total
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_RIGHT, "Importe Total: $       00000", 540, 120, 0);
                cb.EndText();

                //CAE N 
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_RIGHT, "CAE N XXXXXXXXXX", 540, 80, 0);
                cb.EndText();
                //Fecha de Vto. CAE
                cb.SetFontAndSize(bf3, 10);
                cb.BeginText();
                cb.ShowTextAligned(Element.ALIGN_RIGHT, "Fecha de Vto. CAE  XX/XX/XX", 540, 60, 0);
                cb.EndText();






                //BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                //cb.SetColorFill(BaseColor.BLACK);
                //cb.SetFontAndSize(bf, 36);
                //cb.BeginText();
                //cb.ShowTextAligned(Element.ALIGN_CENTER, "ORIGINAL", 270, 450, 0);
                //cb.EndText();


                // Agregar rectángulo para datos de la empresa
                //cb.RoundRectangle(50, 250, 280, 370, 5);
                //cb.Stroke();
                //cb.SetFontAndSize(bf, 12);
                //cb.BeginText();
                //cb.ShowTextAligned(Element.ALIGN_LEFT, datosEmpresa, 60, 350, 0);
                //cb.EndText();

                // Agregar rectángulo para datos del cliente
                //cb.RoundRectangle(300, 250, 530, 370, 5);
                //cb.Stroke();
                //cb.BeginText();
                //cb.ShowTextAligned(Element.ALIGN_LEFT, datosCliente, 310, 350, 0);
                //cb.EndText();

                // Continuar con el resto del contenido
                //doc.Add(new Paragraph("\n"));
                //doc.Add(new Paragraph("\n"));
                //doc.Add(new Paragraph("\n"));
                //doc.Add(new Paragraph("Factura Tipo A"));
                //doc.Add(new Paragraph("\n"));
                //doc.Add(new Paragraph("Cliente: " + nombreCliente));
                //doc.Add(new Paragraph("Dirección: " + direccion));
                //doc.Add(new Paragraph("Fecha: " + fecha));
                //doc.Add(new Paragraph("\n"));
                //doc.Add(new Paragraph("Detalles de la factura:"));

                //PdfPTable table = new PdfPTable(2);
                //table.AddCell("Descripción");
                //table.AddCell("Total");
                //// Agregar filas con los detalles de la factura aquí
                //// Ejemplo: table.AddCell("Producto 1"); table.AddCell("100.00");
                //// Añade tantas filas como necesites

                ////doc.Add(table);

                //doc.Add(new Paragraph("\n"));
                //doc.Add(new Paragraph("Total a pagar: " + total));

                //LOGO
                string imagePath = "C:/Users/Usuario/Pictures/LOGO.png";

                iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(imagePath);

                imagen.SetAbsolutePosition(75, 720);
                imagen.ScaleAbsolute(70, 70);

                doc.Add(imagen);

                //AFIP FOOTER
                string imagePath2 = "C:/Users/Usuario/Pictures/afipfooter.png";

                iTextSharp.text.Image imagen2 = iTextSharp.text.Image.GetInstance(imagePath2);

                imagen2.SetAbsolutePosition(25, 25);
                imagen2.ScaleAbsolute(300, 75);

                doc.Add(imagen2);

                doc.Close();
                writer.Close();

                MessageBox.Show("Factura generada con éxito y guardada en: " + outputPath, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
