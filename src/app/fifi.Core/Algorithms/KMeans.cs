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

      public ClusteringResult Generate()
      {
          ClusteringResult result = new ClusteringResult();

          IList<Centroid> centroids = GenerateRandomCentroids();
          foreach (var centroid in centroids)
          {
              result.Clusters.Add(new Cluster(centroid));
          }

          for (int i = 0; i < maxIterations; i++)
          {
              bool centroidMoved = false;

              do
              {
                  foreach (var profile in dataSet)
                  {
                      Centroid closestCentroid = null;
                      Cluster closestCluster = null;
                      double minDistance = double.MaxValue;
                      foreach (var cluster in result.Clusters)
                      {
                          var centroid = cluster.Centroid;
                          double distance = distanceMetric.Calculate(centroid.Values, profile.Values);
                          if (distance < minDistance)
                          {
                              minDistance = distance;
                              closestCentroid = centroid;
                              closestCluster = cluster;
                          }
                      }

                      ClusterMember member = new ClusterMember(profile, minDistance);
                      closestCluster.Members.Add(member);

                      closestCentroid.Add(profile);
                  }

                  foreach (var cluster in result.Clusters)
                  {
                      if (MoveCentroidIfNeeded(cluster))
                      {
                          centroidMoved = true;
                      }
                  }

              } while (centroidMoved);
          }

          return result;
      }

      private bool MoveCentroidIfNeeded(Cluster cluster)
      {
          Centroid centroid = cluster.Centroid;

          foreach (var member in cluster.Members)
          {
              var profile = member.Profile;
              for (int i = 0; i < profile.CountValues; i++)
              {
                  centroid.GravityCenter[i] += profile.Values[i];
              }

              for (int i = 0; i < centroid.GravityCenter.Length; i++)
              {
                  centroid.GravityCenter[i] /= cluster.Members.Count;
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
