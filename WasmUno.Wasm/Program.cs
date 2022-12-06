

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
        public static async Task<byte[]> DocToPdf(string id)
        {
            try
            {
                using (HttpClient client = new())
                {
                    using (Stream docStream = await client.GetStreamAsync($"https://file.ijro.uz/download/{id}/content"))
                    using (MemoryStream pdfStream = new())
                    {
                        Document document = new Document(docStream);
                        //document.FontSettings=new Aspose.Words.Fonts.FontSettings();
                        //document.FontSettings.SubstitutionSettings.FontConfigSubstitution.Enabled = true;
                        document.Save(pdfStream, SaveFormat.Pdf);
                        return pdfStream.ToArray();
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
