using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core.Algorithms
{
    public class ClusterToMatrixFull
    {
        private IDistanceMetric distanceMetric = new EuclideanMetric();
        ClusteringResult cluster;


        public ClusterToMatrixFull(ClusteringResult input)
        {
            this.cluster = input;
        }



        public double[,] GenerateMatrix()
        {
            return calculatedMatrix(cluster);
        }


        private double[,] calculatedMatrix(ClusteringResult cluster) //Y U NO work - List<ClusterMember> cluster
        {
            int clustersSize = cluster.Clusters.Sum(cster => cster.Members.Count);
            int clustersCount = cluster.Clusters.Count;
            
            double[,] matrix = new double[clustersSize, clustersSize];
            double distance;

            int rowClusterLength;
            int collumClusterLength;

            int collumClusterOffset = 0;
            int collumMemberOffset;

            int rowIndex = 0;
            int collumIndex;
            

            //Nulling the matrix
            for (int i = 0; i < clustersSize; i++)
			{
                matrix[i, i] = 0;
			}


            for (int rowCluster = 0; rowCluster < clustersCount; rowCluster++,collumClusterOffset++) //For all Clusters in row   //for cluster
			{
                rowClusterLength = cluster.Clusters[rowCluster].Members.Count;
                for (int rowMember = 0; rowMember < rowClusterLength; rowMember++, rowIndex++) //For each member in the specific cluster 
                {
                    collumMemberOffset = rowMember+1;
                    collumIndex = rowMember+1;
                    for (int collumCluster = collumClusterOffset; collumCluster < clustersCount; collumCluster++) //For all Clusters in collum
			        {
			            collumClusterLength = cluster.Clusters[collumCluster].Members.Count;
                        for (int collumMember = collumMemberOffset; collumMember < collumClusterLength; collumMember++) //For each member in the specific cluster
			            {
			                distance = distanceMetric.Calculate(cluster.Clusters[rowCluster].Members[rowMember].Profile.Values, cluster.Clusters[collumCluster].Members[collumMember].Profile.Values);
                            matrix[rowIndex, collumIndex] = distance;
                            matrix[collumIndex, rowIndex] = distance;
                            collumIndex++;
			            }
                        collumMemberOffset = 0;
			        }
                }
			}

            return matrix;
        }
    }
}
