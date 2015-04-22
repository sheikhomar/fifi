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
using fifi.Core;


namespace fifi.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.Now;

            //RunProgram();
            TestImport();

            // TODO: Fancy stuff
            var diff = DateTime.Now - start;
            Console.WriteLine("FiFi has finished in {0} ms...", diff.TotalMilliseconds);
            Console.WriteLine("Press any key to kill me :)");
            Console.ReadKey();

        }

        static void TestImport()
        {
            var reader = new StreamReader("UserData.csv");
            CsvDynamicDataImporter importer = new CsvDynamicDataImporter(reader);
            importer.Run();
            reader.Close();
        }

        static void RunProgram()
        {
            //Config
            string codeName = "Out-Bille";
            bool printKMeans = true;
            bool printKMeansMembers = false;
            bool distanceMatrix = true;
            bool multiDimensionalScaling = true;
            bool outlierDetection = true;
            bool outlierDetectionPrintmembers = false;

            var reader = new StreamReader("UserData.csv");
            var importer = new CsvDataImporter(reader);
            var dataCollection = importer.Run();

            //Algo//
            //KMeans
            var k = 5;
            var distanceMetric = new EuclideanMetric();

            var kmeans = new KMeans(dataCollection, k, distanceMetric);

            var start = DateTime.Now;
            var result = kmeans.Generate();
            //Other alogs 


            //File printing//
            var fileName = string.Format("{0}-{1:MM-dd_HH_mm_ss}.txt", codeName, DateTime.UtcNow);

            FileStream fs = new FileStream(fileName, FileMode.CreateNew);
            StreamWriter writer = new StreamWriter(fs);
            writer.Write("Testrun under CodeName {0}. \r\n\r\n", codeName, DateTime.UtcNow);

            if (printKMeans)
                PrintKMeans(writer, result, printKMeansMembers);

            if (distanceMatrix)
                DistanceMatrix(writer, dataCollection, distanceMetric);

            if (multiDimensionalScaling)
                MultiDimensionalScaling(writer, dataCollection, distanceMetric);

            if (outlierDetection)
                OutlierDetectionMethod(writer, result, outlierDetectionPrintmembers);

            writer.Close();
            fs.Close();
        }

        //static void TestImport() //Needs update to fit the new structure
        //{
        //    var reader = new StreamReader("UserData.csv");
        //    var importer = new CsvProfileImporter(reader);

        //    var Profiles = importer.Run();
        //    foreach (var item in Profiles.Take(22))
        //    {
        //        foreach (var value in item.Values)
        //        {
        //            Console.Write("{0}\t", value);
        //        }
        //        Console.WriteLine("\n");
        //    }
        //}

        static void TestConfig()
        {
            ConfigurationSectionHandler v = new ConfigurationSectionHandler();

            var filtersSection = (ConfigurationSectionHandler)ConfigurationManager.GetSection("csvDataImport");
            foreach (Field field in filtersSection.Fields)
            {
                Console.WriteLine("Field index {0} and type: {1}", field.Index, field.Type);
            }

        }


        static void TestMDS()
        {
            double[,] distanceTestOne = { { 0, 87.0, 284.0, 259, 259 }, { 87.0, 0, 195, 183, 222 }, { 284, 195, 0, 123, 260 }, { 259, 183, 123, 0, 140}, {259, 222, 260, 140, 0 } };
            MultiDimensionalScaling a = new MultiDimensionalScaling(distanceTestOne);
            a.Calculate();

            double[,] distanceTestTwo = { { 0, 93.0, 82.0, 133 }, { 93.0, 0, 52, 60 }, { 82, 52, 0, 111 }, { 133, 60, 111, 0} };
            MultiDimensionalScaling b = new MultiDimensionalScaling(distanceTestTwo);
            b.Calculate();
        }


        static void PrintKMeans(StreamWriter writer, ClusteringResult result, bool printMembers)
        {
            writer.WriteLine("KMeans clusters with seed {0}", Centroid.RandomSeed);

            for (int i = 0; i < result.Clusters.Count; i++)
            {
                var cluster = result.Clusters[i];
                var sumOfId = cluster.Members.Sum(e => e.Member.Id);
                var firstId = "None";
                var lastId = "None";

                if (cluster.Members.Count > 0)
                {
                    firstId = cluster.Members[0].Member.Id.ToString();
                    lastId = cluster.Members.Last().Member.Id.ToString();
                }
                writer.WriteLine("Cluster {0}: member(s) {4,4} || #{1,5}, first {2,4}, last {3,4}", i + 1, sumOfId, firstId, lastId, cluster.Members.Count);
            }
            writer.Write("\r\n\r\n");

            if (printMembers)
            {
                for (int valCluster = 0; valCluster < result.Clusters.Count; valCluster++)
                {
                    writer.WriteLine("Cluster {0} members:", valCluster);
                    for (int valMember = 0; valMember < result.Clusters[valCluster].Members.Count; valMember++)
                    {
                        writer.WriteLine("Member {0,4}, id {1,3}", valMember, result.Clusters[valCluster].Members[valMember].Member.Id);
                    }
                    writer.Write("\r\n\r\n");
                }
            }
        }


        static void DistanceMatrix(StreamWriter writer, IdentifiableDataPointCollection dataCollection, IDistanceMetric distanceMetric)
        {
            writer.WriteLine("MatrixFull");
            DistanceMatrix distanceMatrix = new DistanceMatrix(dataCollection, distanceMetric);
            double[,] matrix = distanceMatrix.GenerateMatrix();

            int limiter = 20; //For the full, use matrix.Rank;
            char letter = 'A';

            writer.WriteLine("   |  A  |  B  |  C  |  D  |  E  |  F  |  G  |  H  |  I  |  J  |");
            for (int rowIndex = 0; rowIndex < limiter; rowIndex++)
            {
                writer.Write(" {0} |", letter++);
                for (int collumIndex = 0; collumIndex < limiter; collumIndex++)
                {
                    writer.Write("{0,5:N2}|", matrix[rowIndex, collumIndex]);
                }
                if (letter >= 'z')
                {
                    letter = 'A';
                }
                writer.Write("\r\n");
            }
            writer.Write("\r\n\r\n");
        }

        static void MultiDimensionalScaling(StreamWriter writer, IdentifiableDataPointCollection dataCollection, IDistanceMetric distanceMetric)
        {
            writer.WriteLine("MDS coordinates");

            DistanceMatrix distanceMatrix = new DistanceMatrix(dataCollection, distanceMetric);
            double[,] matrix = distanceMatrix.GenerateMatrix();

            var mds = new MultiDimensionalScaling(matrix);
            double[,] resultMatrix = mds.Calculate(); //a shitty name
            int limiter = 20;

            int matrixFullLength = resultMatrix.Length / resultMatrix.Rank;

            if (limiter > matrixFullLength)
                limiter = matrixFullLength;

            char letter = 'A';

            //Print file index
            writer.Write("    ");
            for (int rowIndex = 0; rowIndex < limiter; rowIndex++, letter++)
            {
                if (letter >= 'z')
                    letter = 'A';
                writer.Write("  {0}  |", letter);
            }
            writer.WriteLine();

            //Print the coordinates
            letter = 'X';
            for (int rowIndex = 0; rowIndex < 2; rowIndex++)
            {
                writer.Write(" {0} |", letter++);
                for (int collumIndex = 0; collumIndex < limiter; collumIndex++)
                {
                    writer.Write("{0,5:N2}|", resultMatrix[rowIndex, collumIndex]);
                }
                writer.Write("\r\n");
            }
            writer.WriteLine("\r\n");
        }

        static void OutlierDetectionMethod(StreamWriter writer, ClusteringResult result, bool outlierDetectionPrintmembers)
        {
            var outlierDetection= new TempOutlierDetection(result);

            var outliers = outlierDetection.Calculate();
            int numbOutliers = outliers.Count;

            writer.WriteLine("OutlierDetection");
            writer.WriteLine("Number of outliers = " + numbOutliers);

            if (outlierDetectionPrintmembers)
            {
                writer.WriteLine("\r\nOutlier members are:");
                for (int index = 0; index < outliers.Count; index++)
                {
                    writer.WriteLine("Outlier[{0}] belongs to cluster {1} as member {2} ", index, outliers[index].belongingCluster, index, outliers[index].identifiableDataPoint);
                } 
            }

            int members = result.Clusters.Sum(cster => cster.Members.Count);
            double ratio = members / numbOutliers;

            writer.WriteLine("\r\nThis run's outlier-ratio is {0} (Members:{1}, Outliers:{2})",ratio,members,numbOutliers);
        }
    }
}
