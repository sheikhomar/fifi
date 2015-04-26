using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using fifi.Core.Algorithms;

namespace fifi.Core
{
    /// <summary>
    /// Represents an asynchronous task that converts <see cref="IdentifiableDataPointCollection"/> 
    /// into a list of <see cref="DrawableDataPoint "/> objects.
    /// </summary>
    public class DataConversionTask
    {
        /// <summary>
        /// Represents a set of arguments used by the task runner.
        /// </summary>
        private class TaskRunnerArgumentSet
        {
            public IdentifiableDataPointCollection Data { get; set; }
            public IDistanceMetric DistanceMetric { get; set; }
        }

        /// <summary>
        /// Occurs when the task is successfully completed.
        /// </summary>
        public event EventHandler<IEnumerable<DrawableDataPoint>> Success;

        /// <summary>
        /// Occurs when the task fails because of unhandled exceptions.
        /// </summary>
        public event EventHandler<IEnumerable<Exception>> Failure;

        /// <summary>
        /// Starts the task.
        /// </summary>
        /// <param name="dataSet">The list of objects that to be converted.</param>
        /// <param name="distanceMetric">The distance metric used to scale down dimensions.</param>
        public void Start(IdentifiableDataPointCollection dataSet, IDistanceMetric distanceMetric)
        {
            var args = new TaskRunnerArgumentSet {Data = dataSet, DistanceMetric = distanceMetric};

            var task = Task.Factory.StartNew<List<DrawableDataPoint>>(TaskRunner, args);

            // Make sure Success and Failure events are run within the caller thread.
            TaskScheduler currentContext = TaskScheduler.FromCurrentSynchronizationContext();
            task.ContinueWith(TaskComplete, currentContext);
            task.ContinueWith(TaskFaulted, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, currentContext);
        }

        // This method is made static on purpose to discourage access to instance members of this class
        // since it is called by another thread than the UI thread. Accessing controls from threads other 
        // than the UI thread will cause problems.
        private static List<DrawableDataPoint> TaskRunner(object arg)
        {
            TaskRunnerArgumentSet options = arg as TaskRunnerArgumentSet;

            DistanceMatrix distanceMatrix = new DistanceMatrix(options.Data, options.DistanceMetric);
            Matrix matrix = distanceMatrix.GenerateMatrix();

            MultiDimensionalScaling mds = new MultiDimensionalScaling(matrix);
            Matrix coordinateMatrix = mds.Calculate();

            List<DrawableDataPoint> drawableDataPoints = new List<DrawableDataPoint>();

            for (int col = 0; col < coordinateMatrix.SecondDimension; col++)
            {
                double x = coordinateMatrix[0, col];
                double y = coordinateMatrix[1, col];
                IdentifiableDataPoint originalDataPoint = options.Data[col];
                drawableDataPoints.Add(new DrawableDataPoint(originalDataPoint, x, y));
            }

            return drawableDataPoints.OrderBy(d => d.Group).ToList();
        }


        protected virtual void OnSuccess(List<DrawableDataPoint> arg)
        {
            var handler = Success;
            if (handler != null)
                handler(this, arg);
        }

        protected virtual void OnFailure(IEnumerable<Exception> arg)
        {
            var handler = Failure;
            if (handler != null)
                handler(this, arg);
        }

        private void TaskComplete(Task<List<DrawableDataPoint>> task)
        {
            OnSuccess(task.Result);
        }

        private void TaskFaulted(Task<List<DrawableDataPoint>> task)
        {
            if (task.Exception != null) 
                OnFailure(task.Exception.InnerExceptions);
        }
    }
}