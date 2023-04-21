using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Vjezba_Barbara_Friščić
{
    public class PdfService
    {
        public static void GenerateNewPdfFileFromString(string path, string inputString)
        {
            try
            {
                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();
                XGraphics graphics = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Arial", 12, XFontStyle.Regular);
                XRect rect = new XRect(80, 40, 80, 40);
                graphics.DrawString(inputString, font, XBrushes.Black, rect, XStringFormats.TopLeft);
                document.Save(path);
                document.Dispose();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
