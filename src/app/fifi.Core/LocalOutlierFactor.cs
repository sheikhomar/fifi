using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace fifi.Core
{
    public class LocalOutlierFactor
    {
        Matrix DistanceMatrix;
        private int KNeighbours;
        List<LocalOutlierFactorPoint> ResultList = new List<LocalOutlierFactorPoint>();

        public LocalOutlierFactor(Matrix distanceMatrix, int kNeighbours)
        {
            DistanceMatrix = distanceMatrix;
            KNeighbours = kNeighbours;
        }

        public void Run()
        {
            DistanceToKthNeighbour(DistanceMatrix);
            LocalReachabilityDensity(KNeighbours);

        }

        private void DistanceToKthNeighbour(Matrix distanceMatrix)
        {
            int lengthDim1 = distanceMatrix.FirstDimension;
            int lengthDim2 = distanceMatrix.SecondDimension;
            
            for (int row = 0; row < lengthDim1; row++)
            {
                LocalOutlierFactorPoint person = new LocalOutlierFactorPoint();
                for (int col = 0; col < lengthDim2; col++)
                {
                    if (row != col)
                        person.DistanceToNeighbours.Add(Tuple.Create<int, double>(col, DistanceMatrix.GetSetMatrix[row, col]));
                }
                person.DistanceToNeighbours.Sort();
                person.DistanceToNeighbours = person.DistanceToNeighbours.Take(KNeighbours).ToList();
                ResultList.Add(person);
            }
        }

        private void LocalReachabilityDensity(int kNeighbours)
        {
            foreach (var person in ResultList)
            {
                double sumOfReachDistK = 0;

                foreach (var id in person.DistanceToNeighbours)
                {
                    sumOfReachDistK += 
                }
            }
        }

        private void CalcReachDistK(LocalOutlierFactorPoint person)
        {
            
        }

        private void LocalOutlierFactor()
        {
            
        }
    }
}