using Couchbase;
using Couchbase.KeyValue;
using System.Threading.Tasks;

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
