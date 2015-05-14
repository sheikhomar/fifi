namespace fifi.Core
{
    public class Outlier
    {
        public DataPoint belongingCluster;
        public ClusterMember identifiableDataPoint;

        public Outlier(ClusterMember inputDataPoint, DataPoint inputBelongingCluster)
        {
            this.identifiableDataPoint = inputDataPoint;
            this.belongingCluster = inputBelongingCluster;
        }



    }
}
