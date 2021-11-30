using Couchbase;
using Couchbase.KeyValue;
using System;
using System.Threading.Tasks;
using ToDoBase.Core;

namespace ToDoBase.Persistence.Services
{
    public class CouchbaseService : ICouchbaseService
    {
        public ICluster Cluster { get; private set; }
        public IBucket ToDoBucket { get; private set; }
        public ICouchbaseCollection UserCollection { get; private set; }
        public ICouchbaseCollection ToDoCollection { get; private set; }

        public CouchbaseService()
        {
            try
            {
                Task.Run(async () =>
                {
                    Cluster = await Couchbase.Cluster.ConnectAsync($"couchbase://{Constants.CB_HOST}", Constants.CB_USER, Constants.CB_PASS);

                    ToDoBucket = await Cluster.BucketAsync(Constants.CB_BUCKET);

                    var defaultScope = await ToDoBucket.DefaultScopeAsync();
                    UserCollection = await defaultScope.CollectionAsync(Constants.CB_USERS_COLLECTION);
                    ToDoCollection = await defaultScope.CollectionAsync(Constants.CB_TODO_ITEMS_COLLECTION);

                    await Cluster.QueryIndexes.CreatePrimaryIndexAsync("todos");
                }).Wait();
            }
            catch (AggregateException exception)
            {
                exception.Handle((e) => throw e);
            }
        }
    }
}
