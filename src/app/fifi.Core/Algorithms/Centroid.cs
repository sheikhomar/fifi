using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core.Algorithms
{
    public class Centroid
    {
        public const int RandomSeed = 100;
        private static Random random = new Random(RandomSeed);
        public Centroid(int dimensions)
        {
            Values = new List<double>();
            GravityCenter = new double[dimensions];
            DataItem = new List<DataItem>();
        }

        public List<double> Values { get; private set; }
        public double[] GravityCenter { get; private set; }
        public IList<DataItem> DataItem { get; private set; }

        public void Add(DataItem profile)
        {
            DataItem.Add(profile);
        }

        public static Centroid GenerateRandom(int dimensions)
        {
            Centroid centroid = new Centroid(dimensions);
            double randomNumber;

            for (int i = 0; i < dimensions; i++)
            {
                randomNumber = (double)random.Next(0, 100) / 100;
                centroid.Values.Add(randomNumber);
            }

            return centroid;
        }
    }
}
