using DocumentFormat.OpenXml.Spreadsheet;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PdfController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\reports\\pdfreports\\" + "dosya 1.pdf");
            var stream = new FileStream(path, FileMode.Create);
            byte[] fileBytes;                
            
            using (MemoryStream memoryStream = new MemoryStream())
            {
                Document document = new Document(PageSize.A4); 
                PdfWriter.GetInstance(document, memoryStream); 
                document.Open(); 
                document.Add(new Paragraph("Traversal Rezervasyon Pdf Raporu")); 
                document.Close();
                fileBytes = memoryStream.ToArray();
            }
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Pdf, "dosya 1.pdf");
        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\reports\\pdfreports\\" + "dosya 1.pdf");
            var stream = new FileStream(path, FileMode.Create);
            byte[] fileBytes;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                Document document = new Document(PageSize.A4);
                PdfWriter.GetInstance(document, stream);
                
                document.Open();
                PdfPTable pdfPTable = new PdfPTable(3);

                pdfPTable.AddCell("Müşteri Adı");
                pdfPTable.AddCell("Müşteri Soyadı");
                pdfPTable.AddCell("Müşteri TC");

                pdfPTable.AddCell("Eylül");
                pdfPTable.AddCell("Yücedağ");
                pdfPTable.AddCell("111111111110");

                pdfPTable.AddCell("Kemal");
                pdfPTable.AddCell("Yıldırım");
                pdfPTable.AddCell("222222222222");

                pdfPTable.AddCell("Mehmet");
                pdfPTable.AddCell("Yılmaz");
                pdfPTable.AddCell("444444444445");

                document.Add(pdfPTable);
                document.Close();

                fileBytes = memoryStream.ToArray();
            }
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Pdf, "Müşteri Listesi.pdf");
        }



    }
}
