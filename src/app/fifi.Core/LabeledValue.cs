using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class LabeledValue
    {
        public LabeledValue(string label, float value)
        {
            Label = label;
            Value = value;
        }

        public string Label { get; private set; }
        public float Value { get; private set; }
    }
}
