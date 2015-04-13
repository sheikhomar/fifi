using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core.Algorithms
{
  /// <summary>
  /// Represents k-means clustering algorithm.
  /// </summary>
  public class KMeans : IClusteringAlgorithm
  {
      private int k;
      private DataSet dataSet;

      public KMeans(DataSet dataSet, int k)
      {
          this.dataSet = dataSet;
          this.k = k;
      }

      public IList<Cluster> Generate()
      {
          IList<Cluster> clusters = new List<Cluster>();

          int dimensions = dataSet.CountDimensions;


          return clusters;
      }

      private IList<Centroid> GenerateRandomCentroids()
      {
          IList<Centroid> centroids = new List<Centroid>();

          int dimensions = dataSet.CountDimensions;

          for (int i = 0; i < k; i++)
          {
              centroids.Add(Centroid.GenerateRandom(dimensions));
          }

          return centroids;
      }
  }
}
