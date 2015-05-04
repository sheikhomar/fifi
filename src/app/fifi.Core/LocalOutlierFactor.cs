using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace fifi.Core
{
    public class LocalOutlierFactor
    {
        private readonly Matrix distanceMatrix;
        private int kNeighbours;
        private readonly List<LocalOutlierFactorPoint> resultList;

        public LocalOutlierFactor(Matrix distanceMatrix, int kNeighbours)
        {
            this.distanceMatrix = distanceMatrix;
            this.kNeighbours = kNeighbours;
            resultList = new List<LocalOutlierFactorPoint>();
        }

        public List<LocalOutlierFactorPoint> Run()
        {
            DistanceToKthNeighbour();
            CalcLocalReachabilityDensity();
            CalcLocalOutlierFactor();
            return resultList;
        }

        private void DistanceToKthNeighbour()
        {
            int lengthDim1 = distanceMatrix.Row;
            int lengthDim2 = distanceMatrix.Column;
            
            for (int row = 0; row < lengthDim1; row++)
            {
                LocalOutlierFactorPoint person = new LocalOutlierFactorPoint();
                for (int col = 0; col < lengthDim2; col++)
                {
                    if (row != col)
                        person.DistanceToNeighbours.Add(Tuple.Create(col, distanceMatrix[row, col]));
                }

                person.DistanceToNeighbours.Sort((x, y) => x.Item2.CompareTo(y.Item2));
                int neighboursToTake = kNeighbours;

                while (neighboursToTake < lengthDim1-1 && person.DistanceToNeighbours[neighboursToTake - 1].Item2 == person.DistanceToNeighbours[neighboursToTake].Item2)
                {
                    neighboursToTake++;
                }

                person.DistanceToNeighbours = person.DistanceToNeighbours.Take(neighboursToTake).ToList();

                person.KDistance = person.DistanceToNeighbours[neighboursToTake - 1].Item2;
                person.ID = row;
                
                resultList.Add(person);
            }
        }

        private void CalcLocalReachabilityDensity()
        {
            double sumOfReachDistK;

            double cardinality;

            foreach (var person in resultList)
            {
                cardinality = person.DistanceToNeighbours.Count();
                sumOfReachDistK = CalcSumOfReachDistK(person);

                person.LocalReachabilityDensity = 1 / (sumOfReachDistK / cardinality);
            }
        }

        private double CalcSumOfReachDistK(LocalOutlierFactorPoint person)
        {
            double sum = 0;

            double KDistNeighbour;


            foreach (var neighbour in person.DistanceToNeighbours)
            {
                KDistNeighbour = resultList[neighbour.Item1].KDistance;

                sum += Math.Max(KDistNeighbour, neighbour.Item2);
            }

            return sum;
        }

        private void CalcLocalOutlierFactor()
        {
            double sumOfLocalReachabilityDensity;

            double cardinality = kNeighbours;

            foreach (var person in resultList)
            {
                sumOfLocalReachabilityDensity = CalcSumOfLocalReachabilityDensity(person);

                person.LocalOutlierFactor = (sumOfLocalReachabilityDensity / cardinality) / person.LocalReachabilityDensity;
            }
        }

        private double CalcSumOfLocalReachabilityDensity(LocalOutlierFactorPoint person)
        {
            double sum = 0;

            foreach (var neighbour in person.DistanceToNeighbours)
            {
                sum += resultList[neighbour.Item1].LocalReachabilityDensity;
            }

            return sum;
        }
    }
}