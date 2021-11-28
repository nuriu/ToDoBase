using Couchbase;
using Couchbase.KeyValue;

namespace ToDoBase.Persistence.Services
{
    public interface ICouchbaseService
    {
        ICluster Cluster { get; }
        IBucket ToDoBucket { get; }
        ICouchbaseCollection UserCollection { get; }
        ICouchbaseCollection ToDoCollection { get; }
    }
}
