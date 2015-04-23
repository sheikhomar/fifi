using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core.Algorithms
{
    public class Cluster
    {
        public const int RandomSeed = 100;
        private static Random random = new Random(RandomSeed);
        private static int _id = 1;

        public Cluster(DataPoint centroid)
        {
            Centroid = centroid;
            Members = new List<ClusterMember>();
            Id = _id++;
        }

        public DataPoint Centroid { get; private set; }
        public IList<ClusterMember> Members { get; private set; }
        public int Id { get; private set; }


        public static DataPoint GenerateRandomCentroid(int dimensions)
        {
            var centroid = new DataPoint(dimensions);

            for (int i = 0; i < dimensions; i++)
            {
                centroid[i] = (double)random.Next(0, 100) / 100;
            }

            return centroid;
        }
    }
}
