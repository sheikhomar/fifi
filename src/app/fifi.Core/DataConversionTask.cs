using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
        public event EventHandler<DataConversionResult> Success;

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

            var task = Task.Factory.StartNew<DataConversionResult>(TaskRunner, args);

            // Make sure Success and Failure events are run within the caller thread.
            TaskScheduler currentContext = TaskScheduler.FromCurrentSynchronizationContext();
            task.ContinueWith(TaskComplete, currentContext);
            task.ContinueWith(TaskFaulted, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, currentContext);
        }

        private static DataConversionResult TaskRunner(object arg)
        {
            TaskRunnerArgumentSet options = arg as TaskRunnerArgumentSet;

            DistanceMatrix distanceMatrix = new DistanceMatrix(options.Data, options.DistanceMetric);
            MultiDimensionalScaling mds = new MultiDimensionalScaling(distanceMatrix);
            Matrix coordinateMatrix = mds.Calculate();

            List<DrawableDataPoint> drawableDataPoints = new List<DrawableDataPoint>();

            for (int col = 0; col < coordinateMatrix.Columns; col++)
            {
                double x = coordinateMatrix[0, col];
                double y = coordinateMatrix[1, col];
                IdentifiableDataPoint originalDataPoint = options.Data[col];
                drawableDataPoints.Add(new DrawableDataPoint(originalDataPoint, x, y));
            }

            var dataPoints = drawableDataPoints.OrderBy(d => d.Group).ToList();

            return new DataConversionResult(dataPoints, distanceMatrix);
        }


        protected virtual void OnSuccess(DataConversionResult arg)
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

        private void TaskComplete(Task<DataConversionResult> task)
        {
            OnSuccess(task.Result);
        }

        private void TaskFaulted(Task<DataConversionResult> task)
        {
            if (task.Exception != null) 
                OnFailure(task.Exception.InnerExceptions);
        }
    }
}