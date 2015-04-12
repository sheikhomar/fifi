using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Data.Configuration.Import
{
    public class ConfigurationSectionHandler : ConfigurationSection
    {
        [ConfigurationProperty("fields")]
        [ConfigurationCollection(typeof(FieldCollection),
           AddItemName = "add")]
        public FieldCollection Fields
        {
            get { return (FieldCollection)this["fields"]; }
        }
    }
}
