using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class NumberOfDimensionsExceededException : Exception
    {
        public NumberOfDimensionsExceededException(string message) : base(message)
        {
            
        }
    }
}
