using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using fifi.Data;
using fifi.Data.Configuration.Import;
using fifi.Core.Algorithms;


namespace fifi.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.Now;

            RunKMeans();

            var diff = DateTime.Now - start;

            // TODO: Fancy stuff
            Console.WriteLine("FiFi has finished in {0} ms...", diff.TotalMilliseconds);
            Console.WriteLine("Press any key to kill me :)");
            Console.ReadKey();

        }

        static void RunKMeans()
        {
            var reader = new StreamReader("UserData.csv");
            var importer = new CsvProfileImporter(reader);


            var dataSet = importer.Run();
            


            var k = 5;
            var distanceMetric = new EuclideanMetric();

            var kmeans = new KMeans(dataSet, k, distanceMetric);

            var start = DateTime.Now;
            var result = kmeans.Generate();

            var fileName = string.Format("kmeans-output-{0:yyyy-MM-dd_HH_mm_ss}.txt", DateTime.UtcNow);


            FileStream fs = new FileStream(fileName, FileMode.CreateNew);
            StreamWriter writer = new StreamWriter(fs);
            string codeName = "fisk, completed in " + (DateTime.Now - start).TotalMilliseconds + " ms";

            writer.WriteLine("Test {1}: {0:yyyy-MM-dd HH:mm}", DateTime.Now, codeName);
            writer.WriteLine("Seed: {0}", Centroid.RandomSeed);
            writer.WriteLine();

            for (int i = 0; i < result.Clusters.Count; i++)
            {
                var cluster = result.Clusters[i];
                var sumOfId = cluster.Members.Sum(e => e.Profile.Id);
                var firstId = "None";
                var lastId = "None";

                if (cluster.Members.Count > 0)
                {
                    firstId = cluster.Members[0].Profile.Id.ToString();
                    lastId = cluster.Members.Last().Profile.Id.ToString();
                }
                writer.WriteLine("Cluster {0}: member(s) {4,4} || #{1,5}, first {2,4}, last {3,4}", i + 1, sumOfId, firstId, lastId, cluster.Members.Count);
            }

            writer.Write("\r\n\r\n");

            for (int valCluster = 0; valCluster < result.Clusters.Count; valCluster++)
            {
                writer.WriteLine("Cluster {0} members:", valCluster);
                for (int valMember = 0; valMember < result.Clusters[valCluster].Members.Count; valMember++)
                {
                    writer.WriteLine("Member {0,4}, id {1,3}", valMember, result.Clusters[valCluster].Members[valMember].Profile.Id);
                }
                writer.Write("\r\n\r\n");
            }

            writer.Close();
            fs.Close();
        }

        static void TestImport()
        {
            var reader = new StreamReader("UserData.csv");
            var importer = new CsvProfileImporter(reader);

            var Profiles = importer.Run();
            foreach (var item in Profiles.Take(22))
            {
                foreach (var value in item.Values)
                {
                    Console.Write("{0}\t", value);
                }
                Console.WriteLine("\n");
            }
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
