

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

using Aspose.Words;

namespace WasmUno.Wasm
{
    public class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Hello from C#!");
            Console.WriteLine(typeof(TestClass).Assembly.FullName);
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
            try
            {
                using (HttpClient client = new())
                {
                    //client.DefaultRequestHeaders.Add("origin", "*");
                    //client.DefaultRequestHeaders.Add("access-control-allow-origin", "*");
                    //client.DefaultRequestHeaders.Add("Access-Control-Allow-Headers", "Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers");
                    //client.DefaultRequestHeaders.Add("access-control-request-method", "GET, POST, PUT, PATCH, OPTIONS, DELETE");
                    using (Stream docStream = await client.GetStreamAsync($"https://file.ijro.uz/download/{id}/content"))
                    using (MemoryStream pdfStream = new())
                    {
                        Document document = new Document(docStream);
                        //document.FontSettings=new Aspose.Words.Fonts.FontSettings();
                        //document.FontSettings.SubstitutionSettings.FontConfigSubstitution.Enabled = true;
                        document.Save(pdfStream, SaveFormat.Pdf);
                        return Convert.ToBase64String(pdfStream.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
