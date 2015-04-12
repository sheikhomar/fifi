using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using fifi.Data;
using fifi.Data.Configuration.Import;


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

        static void TestConfig()
        {
            ConfigurationSectionHandler v = new ConfigurationSectionHandler();

            var filtersSection = (ConfigurationSectionHandler)ConfigurationManager.GetSection("csvDataImport");
            foreach (Field field in filtersSection.Fields)
            {
                Console.WriteLine("Field index {0} and type: {1}", field.Index, field.Type);
            }

        }
    }
}
