using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.WinUI
{
    public class ScatterPlotUtility
    {
        public double ComputeAxisInterval(double AxisMax, double AxisMin)
        {
            double difference = AxisMax - AxisMin;
            double intervalValue = 1;

            while (difference < 1 || difference >= 10)
            {
                if (difference >= 10)
                {
                    difference /= 10;
                    intervalValue *= 10;
                }
                else
                {
                    difference *= 10;
                    intervalValue /= 10;
                }
            }

            return intervalValue;
        }
    }
}
