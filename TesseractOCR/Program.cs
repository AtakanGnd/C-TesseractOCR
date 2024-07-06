using System;
using System.IO;
using Tesseract;

namespace TesseractOCR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string basePath = System.IO.Path.GetFullPath(@"..\..\..\");

            string tessDataPath = Path.Combine(basePath, "tessdata");

            string imagePath = Path.Combine(basePath, "resim.png");
            try
            {
                using (var engine = new TesseractEngine(tessDataPath, "tur", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(imagePath))
                    {
                        using (var page = engine.Process(img, PageSegMode.Auto))
                        {
                            string text = page.GetText();
                            Console.WriteLine("Tanınan Metin:");
                            Console.WriteLine(text);
                        }
                    }
                }

                Console.WriteLine("OCR işlemi tamamlandı.");
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
        }
    }
}
