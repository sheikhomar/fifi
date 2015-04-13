using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class DataSet : IEnumerable<Profile>
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

        public IEnumerator<Profile> GetEnumerator()
        {
            return profiles.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return profiles.GetEnumerator();
        }
    }
}
