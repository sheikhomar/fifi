using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class IdentifiableDataPoint : DataPoint
    {
        public IdentifiableDataPoint(int id, int dimensions) : base(dimensions)
        {
            Id = id;
            Attributes = new List<string>();
        }

        public int Id { get; private set; }
        public List<string> Attributes { get; private set; }

        public void AddAttribute(string name, double value)
        {
            if (Dimensions <= Attributes.Count)
            {
                throw new NumberOfDimensionsExceededException("Cannot add more attributes as the original allowed dimension size has been reached.");
            }

            this.Coordinates[this.Attributes.Count] = value;
            Attributes.Add(name);
        }
    }
}
