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

            if (Dimensions == Attributes.Count)
            {
                throw new NumberOfDimensionsExceededException("hej");
            }

            Attributes.Add(new DataPointAttribute(name, value));
            this[Attributes.Count - 1] = value;
        }

        public DataPointAttribute this[string name]
        {
            get { return Attributes.Where(v => v.Name == name).FirstOrDefault(); }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var attr in Attributes)
                builder.AppendFormat("[{0}: {1}] ", attr.Name, attr.Value);
            return builder.ToString();
        }
    }
}
