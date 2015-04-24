using fifi.Core;

namespace fifi.Data
{
  public interface IDataImporter
  {
      IdentifiableDataPointCollection Run();
  }
}
