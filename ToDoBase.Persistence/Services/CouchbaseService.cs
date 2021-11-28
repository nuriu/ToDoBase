using Couchbase;
using Couchbase.KeyValue;
using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoBase.Core.Extensions;

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
            var CB_HOST = Environment.GetEnvironmentVariable("CB_HOST").DefaultIfEmpty("localhost");
            var CB_USER = Environment.GetEnvironmentVariable("CB_USER").DefaultIfEmpty("todoadmin");
            var CB_PASS = Environment.GetEnvironmentVariable("CB_PASS").DefaultIfEmpty("todoadmin");

            try
            {
                Task.Run(async () =>
                {
                    Cluster = await Couchbase.Cluster.ConnectAsync($"couchbase://{CB_HOST}", CB_USER, CB_PASS);

                    ToDoBucket = await Cluster.BucketAsync("todos");

                    // TODO: create bucket and collections and primary indexes if doesn't exists already
                    // await Cluster.QueryIndexes.CreatePrimaryIndexAsync("todos");
                    // CREATE PRIMARY INDEX ON `default`:`todos`.`_default`.`todoitems` 
                    // CREATE PRIMARY INDEX ON `default`:`todos`.`_default`.`users` 

                    var defaultScope = await ToDoBucket.DefaultScopeAsync();

                    UserCollection = await defaultScope.CollectionAsync("users");
                    ToDoCollection = await defaultScope.CollectionAsync("todoitems");
                }).Wait();
            }
            catch (AggregateException exception)
            {
                exception.Handle((e) => throw e);
            }
        }
    }
}
