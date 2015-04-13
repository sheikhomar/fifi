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
      private int maxIterations;
      private IDistanceMetric distanceMetric;

      public KMeans(DataSet dataSet, int k, IDistanceMetric distanceMetric, int maxIterations = 100)
      {
          this.dataSet = dataSet;
          this.k = k;
          this.maxIterations = maxIterations;
          this.distanceMetric = distanceMetric;
      }

      public IList<Cluster> Generate()
      {
          IList<Cluster> clusters = new List<Cluster>();
          IList<Centroid> centroids = GenerateRandomCentroids();

          int dimensions = dataSet.CountDimensions;

          for (int i = 0; i < maxIterations; i++)
          {
              do
              {
                  foreach (var profile in dataSet)
                  {
                      foreach (var centroid in centroids)
                      {
                          distanceMetric.Calculate(centroid.Values, profile.Values);
                      }
                  }
              } while (CentroidsMove());
          }

          return clusters;
      }

      private bool CentroidsMove()
      {
          // TODO: Implement centroids movement detection.
          return true;
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
