using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;

namespace BlazorBase.Pages.Demo
{
    public partial class PdfGeneration
    {
        private void GenerateNewPdf()
        {
            var doc = new PdfDocument();
            var page = doc.AddPage(); 
            page.Size = PageSize.A4;
            
            // Text Container
            var gfx = XGraphics.FromPdfPage(page, XGraphicsUnit.Millimeter);
            var rect = new XRect(10 ,10 , 100, 100);
            gfx.DrawRectangle(XBrushes.Green, rect);

            // Text
            var xFont = new XFont("Time New Roman", 10, XFontStyle.Bold);
            var xTextFormat = new XTextFormatter(gfx);
            xTextFormat.Alignment = XParagraphAlignment.Left; 
            xTextFormat.DrawString("Lorem ipsum", xFont, XBrushes.Blue, rect, XStringFormats.TopLeft);

            




            doc.Save("test.pdf");


        }
    }
}
