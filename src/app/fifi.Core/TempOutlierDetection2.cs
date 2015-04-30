using System.Collections.Generic;
using fifi.Core;
using MathNet.Numerics;

namespace fifi.Core
{
    public class TempOutlierDetection2
    {
        ClusteringResult clusteringResult;
        private IdentifiableDataPointCollection loadedData;
        double AverageDistance = 0;
        List<Outlier> outlierList = new List<Outlier>();

        public TempOutlierDetection2(ClusteringResult ClusteringResultInput, IdentifiableDataPointCollection LoadedDataInput)
        {
            clusteringResult = ClusteringResultInput;
            loadedData = LoadedDataInput;
        }

        public List<Outlier> Calculate()
        {
            int i;
            IDistanceMetric dist = new EuclideanMetric();
            double[] distance = new double[loadedData.Count];
            foreach (var cluster in clusteringResult.Clusters)
            {
                foreach (var member in cluster.Members)
                {
                    i = 0;
                    foreach (var lMember in loadedData)
                    {
                        distance[i] = dist.Calculate(member.Member, lMember);
                        AverageDistance += findAverageDistanceToFiveNearestPoints(distance);
                        i++;
                    }
                }
            }
            AverageDistance = AverageDistance/loadedData.Count;
            foreach (var cluster in clusteringResult.Clusters)
            {
                FindOutliers(cluster, AverageDistance);
            }

            return outlierList;
        }

        private double findAverageDistanceToFiveNearestPoints(double[] distances)
        {
            double nearestDistance = distances[0],
                secondNearestDistance = 0,
                thirdNearestDistance = 0,
                fourthNearestDistance = 0,
                fifthNearestDistance = 0,
                AverageDistance;

            foreach (var dis in distances)
            {
                if (dis == 0) { }
                else if (dis < nearestDistance)
                {
                    fifthNearestDistance = fourthNearestDistance;
                    fourthNearestDistance = thirdNearestDistance;
                    thirdNearestDistance = secondNearestDistance;
                    secondNearestDistance = nearestDistance;
                    nearestDistance = dis;
                }
            }
            AverageDistance = (nearestDistance + secondNearestDistance + thirdNearestDistance + fourthNearestDistance +
                               fifthNearestDistance)/5;
            return AverageDistance;
        }

        private void FindOutliers(Cluster cluster, double AverageDistance)
        {
            foreach (var member in cluster.Members)
            {
                if (member.Distance > AverageDistance)
                {
                    outlierList.Add(new Outlier(member, cluster.Centroid));
                }
            }
        }
    }
}