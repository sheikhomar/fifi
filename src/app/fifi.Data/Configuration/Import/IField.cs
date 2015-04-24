using System.Collections.Generic;

namespace fifi.Data.Configuration.Import
{
    public interface IField
    {
        int Index { get; }
        FieldType Type { get; }
        string Category { get; }
        IFieldValueCollection Values { get; }
        double MinValue { get; }
        double MaxValue { get; }
    }
}