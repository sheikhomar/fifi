using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core.Algorithms
{
    public class Centroid : DataPoint
    {
        public const int RandomSeed = 100;
        private static Random random = new Random(RandomSeed);

        public Centroid(int dimensions) : base(dimensions)
        {
            
        }

        public static Centroid GenerateRandom(int dimensions)
        {
            Centroid centroid = new Centroid(dimensions);
            
            for (int i = 0; i < dimensions; i++)
            {
                centroid[i] = (double)random.Next(0, 100) / 100;
            }

            return centroid;
        }
    }
}
