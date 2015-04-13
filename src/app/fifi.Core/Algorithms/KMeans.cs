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

          for (int i = 0; i < maxIterations; i++)
          {
              bool centroidMoved = false;

              do
              {
                  foreach (var profile in dataSet)
                  {
                      Centroid closestCentroid = null;
                      double minDistance = double.MaxValue;
                      foreach (var centroid in centroids)
                      {
                          double distance = distanceMetric.Calculate(centroid.Values, profile.Values);
                          if (distance < minDistance)
                          {
                              minDistance = distance;
                              closestCentroid = centroid;
                          }
                      }

                      closestCentroid.Add(profile);
                  }

                  foreach (var centroid in centroids)
                  {
                      if (MoveCentroidIfNeeded(centroid))
                      {
                          centroidMoved = true;
                      }
                  }

              } while (centroidMoved);
          }

          return clusters;
      }

      private bool MoveCentroidIfNeeded(Centroid centroid)
      {
          foreach (var profile in centroid.Profiles)
          {
              for (int i = 0; i < profile.CountValues; i++)
              {
                  centroid.GravityCenter[i] += profile.Values[i];
              }

              for (int i = 0; i < centroid.GravityCenter.Length; i++)
              {
                  centroid.GravityCenter[i] /= centroid.Profiles.Count;
              }
          }

          bool centroidHasMoved = false;

          for (int i = 0; i < centroid.Values.Length; i++)
          {
              if (centroid.Values[i] != centroid.GravityCenter[i])
              {
                  centroidHasMoved = true;
              }
          }

          if (centroidHasMoved)
          {
              for (int i = 0; i < centroid.Values.Length; i++)
              {
                  centroid.Values[i] = centroid.GravityCenter[i];
              }
          }

          return centroidHasMoved;
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
