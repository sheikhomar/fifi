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
            //RunKMeans();
            double[,] Distance = { { 0, 93.0, 82.0, 133 }, { 93.0, 0, 52, 60 }, { 82, 52, 0, 111 }, { 133, 60, 111, 0} };
            //double[,] Distance = { { 0, 87.0, 284.0, 259, 259 }, { 87.0, 0, 195, 183, 222 }, { 284, 195, 0, 123, 260 }, { 259, 183, 123, 0, 140 }, { 259, 222, 260, 140, 0 } };
            MultiDimensionalScaling a = new MultiDimensionalScaling(Distance);
            a.Calculate();
            var start = DateTime.Now;

            RunProgram();

            var diff = DateTime.Now - start;

            // TODO: Fancy stuff
            Console.WriteLine("FiFi has finished in {0} ms...", diff.TotalMilliseconds);
            Console.WriteLine("Press any key to kill me :)");
            Console.ReadKey();

        }

        static void RunProgram()
        {
            //Config
            string codeName = "Panda";
            bool printKMeans = true;
            bool printKMeansMembers = false;
            bool matrixList = false;
            bool matrixFull = true;
            bool mdsRun = true;

            var reader = new StreamReader("UserData.csv");
            var importer = new CsvProfileImporter(reader);
            var dataSet = importer.Run();

            //Algo//
            //KMeans
            var k = 5;
            var distanceMetric = new EuclideanMetric();

            var kmeans = new KMeans(dataSet, k, distanceMetric);

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

            if (matrixList) //Old matrix test
                MatrixList(writer, result);

            if (matrixFull)
                MatrixFull(writer, result);

            if (mdsRun)
                MDSRun(writer, result);

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


        static void TestMDS()
        {
            double[,] Distance = { { 0, 87.0, 284.0, 259, 259 }, { 87.0, 0, 195, 183, 222 }, { 284, 195, 0, 123, 260 }, { 259, 183, 123, 0, 140}, {259, 222, 260, 140, 0 } };
            MultiDimensionalScaling a = new MultiDimensionalScaling(Distance);
            a.Calculate();
        }


        static void PrintKMeans(StreamWriter writer, ClusteringResult result, bool printMembers)
        {
            writer.WriteLine("KMeans clusters with seed {0}", Centroid.RandomSeed);

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

            if (printMembers)
            {
                for (int valCluster = 0; valCluster < result.Clusters.Count; valCluster++)
                {
                    writer.WriteLine("Cluster {0} members:", valCluster);
                    for (int valMember = 0; valMember < result.Clusters[valCluster].Members.Count; valMember++)
                    {
                        writer.WriteLine("Member {0,4}, id {1,3}", valMember, result.Clusters[valCluster].Members[valMember].Profile.Id);
                    }
                    writer.Write("\r\n\r\n");
                }
            }
        }



        static void MatrixList(StreamWriter writer, ClusteringResult result)
        {
            writer.WriteLine("MatrixList");
            ClusterToMatrix distanceMatrix = new ClusterToMatrix(result);
            List<double[,]> matrices = distanceMatrix.GenerateMatrix();

            int matrixNumber = 0;
            char rowIndexChar = 'A';

            foreach (var matrix in matrices)
            {
                int matrixLength = 6; //(int)Math.Sqrt(matrices[0].Length); //should yeald the row/collum length for a !!symmetrical!! matrix
                writer.WriteLine("Matrix" + matrixNumber++); //The matrix have no implementation of a unique ID
                writer.WriteLine("    A  |  B  |  C  |  D  |  E..");
                for (int row = 0; row < matrixLength; row++)
                {
                    writer.Write(rowIndexChar++ + "|");
                    for (int collum = 0; collum < matrixLength; collum++)
                    {
                        writer.Write("{0,5:N2}|", matrix[row, collum]);
                    }

                    writer.Write("\r\n");
                }
                rowIndexChar = 'A';
                writer.Write("\r\n\r\n");
            }
            writer.Write("\r\n\r\n");
        }


        static void MatrixFull(StreamWriter writer, ClusteringResult result)
        {
            writer.WriteLine("MatrixFull");
            DistanceMatrix distanceMatrix = new DistanceMatrix(result);
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

        static void MDSRun(StreamWriter writer, ClusteringResult result)
        {
            writer.WriteLine("MDS final matrix");

            DistanceMatrix distanceMatrix = new DistanceMatrix(result);
            double[,] matrix = distanceMatrix.GenerateMatrix();

            MultiDimensionalScaling mds = new MultiDimensionalScaling(matrix);
            double[,] resultMatrix = mds.Calculate(); //a shitty name
            int limiter = 20;

            if (limiter > resultMatrix.Rank)
                limiter = resultMatrix.Rank;

            char letter = 'A';
            writer.WriteLine("   |  A  |  B  |  C  |  D  |  E  |  F  |  G  |  H  |  I  |  J  |");
            for (int rowIndex = 0; rowIndex < limiter; rowIndex++)
            {
                writer.Write(" {0} |", letter++);
                for (int collumIndex = 0; collumIndex < limiter; collumIndex++)
                {
                    writer.Write("{0,5:N2}|", resultMatrix[rowIndex, collumIndex]);
                }
                if (letter >= 'z')
                    letter = 'A';
                writer.Write("\r\n");
            }
            writer.WriteLine("\r\n");


            writer.WriteLine("MDS koordinates");
            //This will be added when we know what structure the final koordinates are in.

        }
    }
}
