using System.Collections.Generic;

namespace fifi.Data.Configuration.Import
{
    public interface IFieldValueCollection : IEnumerable<IFieldValue>
    {
        double? GetAssignedValue(string stringValue);
    }
}