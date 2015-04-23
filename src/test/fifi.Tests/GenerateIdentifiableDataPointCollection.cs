﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fifi.Core;
using fifi.Core.Algorithms;

namespace fifi.Tests
{
    public class GenerateIdentifiableDataPointCollection
    {
        private IdentifiableDataPointCollection dataCollection;
        private IDistanceMetric distanceMetric;
        private IdentifiableDataPoint dataPoint;
        private int collectionSize;

        public GenerateIdentifiableDataPointCollection(int size)
        {
            collectionSize = size;
        }

        public IdentifiableDataPointCollection Generate()
        {
            distanceMetric = new EuclideanMetric();
            dataCollection = new IdentifiableDataPointCollection();
            Random rand = new Random();

            int id = 0;
            int dimentions = 5;

            dataCollection = new IdentifiableDataPointCollection();
            for (int i = 0; i < collectionSize; i++)
            {
                dataPoint = new IdentifiableDataPoint(++id, dimentions);
                dataCollection.AddItem(dataPoint);
            }

            for (int i = 0; i < collectionSize; i++)
            {
                dataCollection[i].AddAttribute("Gender", 1d);
                if ((i % 10) < 4)
                {
                    dataCollection[i].AddAttribute("Income", 1d);
                }
                else
                {
                    dataCollection[i].AddAttribute("Income", 0.2858d);
                }
                dataCollection[i].AddAttribute("Age", 0.16d);
                if ((i % 10) < 2 || (i % 10) > 3)
                {
                    dataCollection[i].AddAttribute("Purchase", 1d);
                }
                else
                {
                    dataCollection[i].AddAttribute("Purchase", 0.5d);
                }
                if ((i % 10) < 2)
                {
                    dataCollection[i].AddAttribute("Control", 0.5d);
                }
                else
                {
                    dataCollection[i].AddAttribute("Control", 1d);
                }
                if ((i % 10) == 9)
                {
                    dataCollection[i].AddAttribute("Gender", 0d);
                    dataCollection[i].AddAttribute("Income", 0.1429d);
                    dataCollection[i].AddAttribute("Age", 0.16d);
                    dataCollection[i].AddAttribute("Purchase", 1d);
                    dataCollection[i].AddAttribute("Control", 0d);
                }
            }
            return dataCollection;
        }
    }
}
