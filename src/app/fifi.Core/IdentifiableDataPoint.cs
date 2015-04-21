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
            Attributes = new List<DataPointAttribute>();
        }

        public int Id { get; private set; }
        public IList<DataPointAttribute> Attributes { get; private set; }

        public void AddAttribute(string name, double value)
        {
            Attributes.Add(new DataPointAttribute(name, value));
            this[Attributes.Count - 1] = value;
        }

        public DataPointAttribute this[string name]
        {
            get { return Attributes.Where(v => v.Name == name).FirstOrDefault(); }
        }
    }
}
