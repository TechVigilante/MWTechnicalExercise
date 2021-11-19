using System;
using System.IO;

namespace Meltwater_Technical_Exercise
{
    class Program
    {
        private static void Main()
        {
            string fileText = "";
            string itemsText = "";

            if (File.Exists("FileToRedact.txt"))
            {
                fileText = File.ReadAllText("FileToRedact.txt");
            }
            else
            {
                Console.Write("File to sanitize does not exist.");
                Environment.Exit(0);
            }

            if (File.Exists("ItemsToRedact.txt"))
            {
                itemsText = File.ReadAllText("ItemsToRedact.txt");
            }
            else
            {
                Console.Write("File of items to redact does not exist.");
                Environment.Exit(0);
            }

            if (fileText == "" | itemsText == "")
            {
                Console.WriteLine("Either the file to redact or the items to redact are empty. Nothing to do here.");
                Environment.Exit(0);
            }

            var myRedactor = new DocumentRedactor();
            myRedactor.SetItemsToRedact(itemsText);
            var sanitizedText = myRedactor.Sanitize(fileText, "XXXX");
            Console.WriteLine(sanitizedText);
        }
    }
}
