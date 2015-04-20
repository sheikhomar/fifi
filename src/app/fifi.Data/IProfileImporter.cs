using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fifi.Core;

namespace fifi.Data
{
  public interface IProfileImporter
  {
      DataCollection Run();
  }
}
