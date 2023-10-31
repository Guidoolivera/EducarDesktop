using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CustomPdfPageEvent : PdfPageEventHelper
{
    private string nombreCurso;

    public CustomPdfPageEvent(string nombreCurso)
    {
        this.nombreCurso = nombreCurso;
    }

    public override void OnEndPage(PdfWriter writer, Document document)
    {
        // Crear el contenido del footer aquí
        PdfPTable footer = new PdfPTable(1);
        footer.TotalWidth = 500;
        footer.DefaultCell.Border = 0;

        // Agregar contenido al footer
        string fecha = DateTime.Now.ToString();
        PdfPCell cell = new PdfPCell(new Phrase(fecha));
        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        footer.AddCell(cell);

        // Dibujar el footer en la página
        footer.WriteSelectedRows(0, -1, 36, 50, writer.DirectContent);

        // Dibujar el nombre del curso en la ubicación deseada
        float cursoX = 500;  // Ajusta esto para la posición horizontal
        float cursoY = 800;  // Ajusta esto para la posición vertical
        writer.DirectContent.BeginText();
        writer.DirectContent.ShowTextAligned(Element.ALIGN_CENTER, nombreCurso, cursoX, cursoY, 0);
        writer.DirectContent.EndText();
    }
}