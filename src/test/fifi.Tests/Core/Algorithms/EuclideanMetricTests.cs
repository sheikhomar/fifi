using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using fifi.Core.Algorithms;
using fifi.Core;

namespace fifi.Tests.Core.Algorithms
{
    [TestFixture]
    public class EuclideanMetricTests
    {
        private static int dimensions = 5;
        private EuclideanMetric metric;
        private DataPoint dataPointA = new DataPoint(dimensions);
        private DataPoint dataPointB = new DataPoint(dimensions);


        [SetUp]
        public void SetUp()
        {
            metric = new EuclideanMetric(); 
        }

        //private void convertFromStringToDataPoint(DataPoint dataPoint, string[] stringWithCoordinates)
        //{
        //    double[] coordinates = new double[dimensions];
        //    for (int index = 0; index < dimensions; index++)
        //    {
        //        coordinates[index] = Convert.ToDouble(stringWithCoordinates[index]);
        //    }
        //    dataPoint.SetCoordinates(coordinates);
        //}

        //test ideas:
        // close to 0, close to max, medium results, swapping A and B should yeild the same, differnt array size (this will result in an error)
        //Notes: I somehow need to make the below coordinate definition work with our test runs... Several people suggest TestCaseSource - but I can't get a result with that?!



        ////Please make this match the dimensions
        //public static double[]   coorZero = { 0.0, 0.0, 0.0, 0.0, 0.0 };
        //public static double[]      coorA = { 1, 2, 3, 5, 5 };
        //public static double[]      coorB = { 1, 1, 1, 1, 1 };
        //public static double[]      coorC = { 0.0, 0.0, 0.0, 0.0, 0.0 };
        //public static double[]      coorD = { 0.0, 0.0, 0.0, 0.0, 0.0 };
        //public static double[]      coorE = { 0.0, 0.0, 0.0, 0.0, 0.0 };
        //public static double[]      coorF = { 0.0, 0.0, 0.0, 0.0, 0.0 };

        //[TestCase(coorZero, coorZero, ExpectedResult=0)]
        //[TestCase(coorA, coorA, ExpectedResult = 0)]
        //[TestCase(coorZero, coorB, ExpectedResult = 1)]
        //public double TestEuclideanMetric_DataPoint(double[] pointACoordinates, double[] pointBCoordinates)
        //{
        //    //Convert from double to dataPoint
        //    dataPointA.SetCoordinates(pointACoordinates);
        //    dataPointA.SetCoordinates(pointBCoordinates);

        //    return metric.Calculate(dataPointA, dataPointB); ;
        //}






    //    [SetUp]
    //    public void Setup()
    //    {
    //        metric = new EuclideanMetric();
    //    }

    //    [Test]
    //    public void ShouldCalculateDistanceFromSamePoint()
    //    {
    //        var a = new double[] { 1, 2 };
    //        var result = metric.Calculate(a, a);
    //        Assert.AreEqual(0f, result);
    //    }

    //    [Test]
    //    public void ShouldCalculateDistanceFromDifferentPoints()
    //    {
    //        var a = new double[] { 1, 2, 6 };
    //        var b = new double[] { 2, 4, 8 };
    //        var result = metric.Calculate(a, b);
    //        Assert.AreEqual(3.0f, result);
    //    }
    }
}
