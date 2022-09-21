﻿

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
                using (Stream docStream = await client.GetStreamAsync($"https://file.us.uz/download/{id}/content"))
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
    }
}
