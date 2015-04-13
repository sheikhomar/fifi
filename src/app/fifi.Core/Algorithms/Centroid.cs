﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core.Algorithms
{
    public class Centroid
    {
        public Centroid(int dimensions)
        {
            Values = new double[dimensions];
        }

        public double[] Values { get; private set; }

        public static Centroid GenerateRandom(int dimensions)
        {
            Centroid centroid = new Centroid(dimensions);
            Random random = new Random();
            for (int i = 0; i < dimensions; i++)
            {
                centroid.Values[i] = (double)random.Next(0, 100) / 100;
            }

            return centroid;
        }
    }
}
