﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core.Algorithms
{
  public interface IClusteringAlgorithm
  {
      ClusteringResult Calculate();
  }
}