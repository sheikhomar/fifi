using System;

namespace fifi.Data
{
    public class InvalidFieldValueException : Exception
    {
        public InvalidFieldValueException(int lineNumber, int field)
            : base(string.Format("Data contains invalid value at row {0} field index {1}.", lineNumber, field))
        {
            LineNumber = lineNumber;
            Field = field;
        }
        
        public int LineNumber { get; private set; }
        public int Field { get; private set; }
    }
}