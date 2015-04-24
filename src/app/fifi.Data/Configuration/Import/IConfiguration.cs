using System.Collections.Generic;

namespace fifi.Data.Configuration.Import
{
    public interface IConfiguration
    {
        int DimensionCount { get; }
        IFieldCollection Fields { get; }
    }
}