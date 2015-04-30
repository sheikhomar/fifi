using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fifi.Core;

namespace fifi.Core
{
    public class TempOutlierDetection
    {
        ClusteringResult input;
        double AverageDistance = 0;
        List<Outlier> outlierList = new List<Outlier>();

        public TempOutlierDetection(ClusteringResult Input)
        {
            input = Input;
        }

        public List<Outlier> Calculate()
        {
            foreach (var Cluster in input.Clusters)
            {
                FindOutliers(Cluster);
            }
            return outlierList;
        }
        
        private double FindAverageDistance(Cluster Cluster)
        {
            foreach (var Member in Cluster.Members)
            {
                AverageDistance += Member.Distance;
            }
            return AverageDistance/Cluster.Members.Count;
        }

        private void FindOutliers(Cluster Cluster)
        {
            AverageDistance = FindAverageDistance(Cluster);

            foreach (var Member in Cluster.Members)
	        {
		        if (Member.Distance > AverageDistance) 
                {
                    outlierList.Add(new Outlier(Member, Cluster.Centroid));
                }
	        }
        }
    }
}
