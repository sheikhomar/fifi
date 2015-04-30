using System;

namespace fifi.Data
{
    public class InvalidNumericValueException : Exception
    {
        public InvalidNumericValueException(int lineNumber, int field)
            : base(string.Format("Invalid numeric value detected at row {0} field index {1}.", lineNumber, field))
        {
            LineNumber = lineNumber;
            Field = field;
        }
        
        public int LineNumber { get; set; }
        public int Field { get; private set; }
    }
}