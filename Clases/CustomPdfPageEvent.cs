using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CustomPdfPageEvent : PdfPageEventHelper
{
    public override void OnEndPage(PdfWriter writer, Document document)
    {
        // Crear el contenido del footer aquí
        PdfPTable footer = new PdfPTable(1);
        footer.TotalWidth = 750;
        footer.DefaultCell.Border = 0;

        // Agregar contenido al footer
        string fecha = DateTime.Now.ToString();
        PdfPCell cell = new PdfPCell(new Phrase(fecha));
        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        footer.AddCell(cell);

        // Dibujar el footer en la página
        footer.WriteSelectedRows(0, -1, 36, 50, writer.DirectContent);
    }
}
