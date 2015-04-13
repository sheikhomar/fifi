using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class DataSet
    {
        private IList<Profile> profiles;
        private int dimensions = 0;

        public DataSet()
        {
            profiles = new List<Profile>();
        }

        public void AddItem(Profile profile)
        {
            if (dimensions == 0)
                dimensions = profile.CountValues;
            profiles.Add(profile);
        }

        public int CountDimensions
        {
            get { return dimensions; }
        }
    }
}
