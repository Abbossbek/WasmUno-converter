

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using PdfSharp;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using PdfSharp.Pdf;

namespace WasmUno.Wasm
{
    public class Program
    {
        static int Main(string[] args)
        {
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("ORg4AjUWIQA/Gnt2VVhiQlFadVlJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRdk1hW39WcH1RRmRfVEQ=");
            Console.WriteLine("Hello from C#!");
            return 0;
        }
    }
    public static class TestClass
    {
        public static string Hello(string name)
        {
            Console.WriteLine($"Hello {name}!");
            return $"Hello {name}!";
        }
        public static async Task<string> DocToPdf(string id)
        {
            using (HttpClient client = new())
            {
                var s = Environment.OSVersion.Platform;
                using (Stream docStream = await client.GetStreamAsync($"https://file.us.uz/download/{id}/content"))
                using (MemoryStream pdfStream = new())
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    docStream.Position = 0;
                    var html = /*"<p><h1>Hello World</h1>This is html rendered text</p>"; //*/DocxToHtml.Docx.ConvertToHtml(docStream);
                    Console.WriteLine("Coverted MemoryStream docx в html");
                    PdfDocument pdf = PdfGenerator.GeneratePdf(html, PageSize.A4);
                    Console.WriteLine("Convert html to pdf");
                    pdf.Save(pdfStream);
                    return Convert.ToBase64String(pdfStream.ToArray());
                }
            }
        }
    }
}
