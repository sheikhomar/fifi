using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fifi.Data;

namespace fifi.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Fancy stuff
            Console.WriteLine("fifi");
            Console.ReadKey();
        }

        static void TestImport()
        {
            var reader = new StreamReader("UserData.csv");
            var importer = new CsvProfileImporter(reader);
            importer.Run();
        }
    }
}
