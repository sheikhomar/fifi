using System;

namespace fifi.Core
{
    public class ClusterMember
    {
        public ClusterMember(IdentifiableDataPoint member, double distance)
        {
            if (member == null) 
                throw new ArgumentNullException("member");
            if (distance < 0)
                throw new ArgumentException("Distance must be a positive integer", "distance");

            Member = member;
            Distance = distance;
        }

        public IdentifiableDataPoint Member { get; private set; }
        public double Distance { get; private set; }
    }
}
