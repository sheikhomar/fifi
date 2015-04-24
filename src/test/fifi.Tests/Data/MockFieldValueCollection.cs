using System.Collections.Generic;
using System.Linq;
using fifi.Data.Configuration.Import;

namespace fifi.Tests.Data
{
    internal class MockFieldValueCollection : List<IFieldValue>, IFieldValueCollection
    {
        public double? GetDoubleValueFor(string stringValue)
        {
            var fieldValue = this.FirstOrDefault(e => e.Name == stringValue);
            if (fieldValue != null)
                return fieldValue.Value;
            return null;
        }
    }
}