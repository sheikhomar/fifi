using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Data.Configuration.Import
{
    public class Field : ConfigurationElement
    {
        const string AttributeIndex = "index";
        const string AttributeType = "type";

        [ConfigurationProperty(AttributeIndex, IsRequired = true)]
        public int Index
        {
            get { return (int)this[AttributeIndex]; }
            set { this[AttributeIndex] = value; }
        }

        [ConfigurationProperty(AttributeType, IsRequired = true)]
        public string Type
        {
            get { return (string)this[AttributeType]; }
            set { this[AttributeType] = value; }
        }
    }
}
