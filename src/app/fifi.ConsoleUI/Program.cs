using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using fifi.Data;
using fifi.Data.Configuration.Import;
using fifi.Core;


namespace fifi.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to FiFi-DS MMXV");
            var start = DateTime.Now;

            RunProgram();
            //TestImport();

            // TODO: Fancy stuff
            var diff = DateTime.Now - start;
            Console.WriteLine("FiFi has finished in {0} ms...", diff.TotalMilliseconds);
            Console.WriteLine("Press any key to kill me :)");
            Console.ReadKey();

        }

        static void TestImport()
        {
            IConfiguration configuration =
                (ConfigurationSectionHandler) ConfigurationManager.GetSection("csvDataImport");
            var reader = new StreamReader("UserData.csv");
            CsvDynamicDataImporter importer = new CsvDynamicDataImporter(reader, configuration);
            var dataSet = importer.Run();
            reader.Close();
        }

        static void RunProgram()
        {
            //Config
            string codeName = "Out-Cikade";
            bool printKMeans = true;
            bool printKMeansMembers = false;
            bool distanceMatrix = true;
            bool multiDimensionalScaling = true;
            bool outlierDetection = false;
            bool outlierDetectionPrintmembers = false;
            bool outlierDetection2 = false;
            bool localOutlierFactor = true;

            IConfiguration configuration =
                (ConfigurationSectionHandler)ConfigurationManager.GetSection("csvDataImport");
            var reader = new StreamReader("UserData.csv");
            var importer = new CsvDynamicDataImporter(reader, configuration);
            var dataCollection = importer.Run();

            //Algo//
            //KMeans
            var k = 5;
            var distanceMetric = new EuclideanMetric();

            var kmeans = new KMeans(dataCollection, k, distanceMetric);

            var start = DateTime.Now;
            var result = kmeans.Calculate();
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

            if (outlierDetection2)
                OutlierDetectionMethod2(writer, result, outlierDetectionPrintmembers, dataCollection);

            if (localOutlierFactor)
                LocalOutlierFactorD(4, dataCollection, distanceMetric);

            writer.Close();
            fs.Close();
        }


        static void PrintKMeans(StreamWriter writer, ClusteringResult result, bool printMembers)
        {
            writer.WriteLine("KMeans clusters");

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
            DistanceMatrix matrix = new DistanceMatrix(dataCollection, distanceMetric);

            int limiter = 20; //For the full, use matrix.Rank;
            char letter = 'A';

            writer.WriteLine("   |  A  |  B  |  C  |  D  |  E  |  F  |  G  |  H  |  I  |  J  |");
            for (int rowIndex = 0; rowIndex < limiter; rowIndex++)
            {
                writer.Write(" {0} |", letter++);
                for (int columnIndex = 0; columnIndex < limiter; columnIndex++)
                {
                    writer.Write("{0,5:N2}|", matrix[rowIndex, columnIndex]);
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

            var mds = new MultiDimensionalScaling(distanceMatrix);
            Matrix resultMatrix = mds.Calculate(); //a shitty name
            int limiter = 20;


            if (limiter > resultMatrix.Column)
                limiter = resultMatrix.Column;

            char letter = 'A';

            //Print file index
            writer.Write("    ");
            for (int columnIndex = 0; columnIndex < limiter; columnIndex++, letter++)
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
                for (int columnIndex = 0; columnIndex < limiter; columnIndex++)
                {
                    writer.Write("{0,5:N2}|", resultMatrix[rowIndex, columnIndex]);
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

        static void OutlierDetectionMethod2(StreamWriter writer, ClusteringResult result, bool outlierDetectionPrintmembers, IdentifiableDataPointCollection data)
        {
            var outlierDetection = new TempOutlierDetection2(result, data);

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

            writer.WriteLine("\r\nThis run's outlier-ratio is {0} (Members:{1}, Outliers:{2})", ratio, members, numbOutliers);
        }

        static void LocalOutlierFactorD(int kNeighbours, IdentifiableDataPointCollection dataCollection, IDistanceMetric distanceMetric)
        {
            DistanceMatrix distanceMatrix = new DistanceMatrix(dataCollection, distanceMetric);
            var outlierDetection = new LocalOutlierFactor(distanceMatrix, kNeighbours);
            var list = outlierDetection.Run();

            foreach (var person in list)
            {
                Console.WriteLine("Person: {0} has the Local Outlier Factor of {1}", person.ID, person.LocalOutlierFactor);
            }
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
            double[,] distanceTestOne = { { 0, 87.0, 284.0, 259, 259 }, { 87.0, 0, 195, 183, 222 }, { 284, 195, 0, 123, 260 }, { 259, 183, 123, 0, 140 }, { 259, 222, 260, 140, 0 } };
            Matrix distanceTestOneMatrix = new Matrix(distanceTestOne.GetLength(0), distanceTestOne.GetLength(1));
            distanceTestOneMatrix.GetSetMatrix = distanceTestOne;
            MultiDimensionalScaling a = new MultiDimensionalScaling(distanceTestOneMatrix);
            a.Calculate();

            double[,] distanceTestTwo = { { 0, 93.0, 82.0, 133 }, { 93.0, 0, 52, 60 }, { 82, 52, 0, 111 }, { 133, 60, 111, 0 } };
            Matrix distanceTestTwoMatrix = new Matrix(distanceTestTwo.GetLength(0), distanceTestTwo.GetLength(1));
            distanceTestTwoMatrix.GetSetMatrix = distanceTestTwo;
            MultiDimensionalScaling b = new MultiDimensionalScaling(distanceTestTwoMatrix);
            b.Calculate();
        }
    }
}
