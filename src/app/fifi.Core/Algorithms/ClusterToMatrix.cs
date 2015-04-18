using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core.Algorithms
{
    public class ClusterToMatrix
    {
        private IDistanceMetric distanceMetric  = new EuclideanMetric();
        List<double[,]> result = new List<double[,]>();
        int size;
        ClusteringResult cluster;


        public ClusterToMatrix(ClusteringResult input)
        {
            this.cluster = input;
            this.size = input.Clusters.Count;
        }


        public List<double[,]> GenerateMatrix()
        {
            for (int i = 0; i < size; i++)
            {
                //result.Add(calculatedMatrix(cluster.Clusters[i]); Y U NO work?!
                result.Add(calculatedMatrix(cluster, i));
            }

            return result;
        }


        private double[,] calculatedMatrix(ClusteringResult cluster, int index) //Y U NO work - List<ClusterMember> cluster
        {
            int oldCollum = 1;
            int size = cluster.Clusters[index].Members.Count();
            double[,] matrix = new double[size,size];
            double distance;

            for (int row = 0; row < size; row++)
            {
                for (int collum = oldCollum; collum < size; collum++)
                {
                    distance = distanceMetric.Calculate(cluster.Clusters[index].Members[row].Profile.Values, cluster.Clusters[index].Members[collum].Profile.Values);
                    matrix[row, collum] = distance; //This assumes that the matrix is symmetrical
                    matrix[collum, row] = distance;
                }
            }

            //Nulling the diagonal part of the matrix (x,x)
            for (int i = 0; i < size; i++)
            {
                matrix[i, i] = 0;
            }

            return matrix;
        }
    }
}
