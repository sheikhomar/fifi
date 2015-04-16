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
        public Centroid(int dimensions)
        {
            Values = new double[dimensions];
            GravityCenter = new double[dimensions];
            Profiles = new List<Profile>();
        }

        public double[] Values { get; private set; }
        public double[] GravityCenter { get; private set; }
        public IList<Profile> Profiles { get; private set; }

        public void Add(Profile profile)
        {
            Profiles.Add(profile);
        }

        public static Centroid GenerateRandom(int dimensions)
        {
            Centroid centroid = new Centroid(dimensions);
            Random random = new Random(RandomSeed);
            for (int i = 0; i < dimensions; i++)
            {
                centroid.Values[i] = (double)random.Next(0, 100) / 100;
            }

            return centroid;
        }
    }
}
