using System.Text;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

namespace Core.Services
{
    public static class PdfReaderService
    {
        public static string ExtractTextFromPdf(string filePath)
        {
            var pageContent = new StringBuilder();
            var pdfReader = new PdfReader(filePath);
            var pdfDoc = new PdfDocument(pdfReader);
            for (var page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                pageContent.Append(PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), strategy)).Append(' ');
            }
            pdfDoc.Close();
            pdfReader.Close();
            return pageContent.ToString();
        }
    }
}
