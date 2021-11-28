using Couchbase.KeyValue;
using Couchbase.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBase.Core.Entities;
using ToDoBase.Core.Services;

namespace ToDoBase.Persistence.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly ICouchbaseService _couchbaseService;
        private readonly IUserService _userService;

        public ToDoItemService(ICouchbaseService couchbaseService, IUserService userService)
        {
            _couchbaseService = couchbaseService;
            _userService = userService;
        }

        public async Task<List<ToDoItem>> ListItems(string username, int page, int itemsPerPage)
        {
            var query =
                "select todoitems.* from `todos`._default.todoitems " +
                "where creator.username=$1 " +
                "order by createdAt " +
                "limit $2 " +
                "offset $3;";

            var itemsQueryResult = await _couchbaseService.Cluster.QueryAsync<ToDoItem>(
                query, new QueryOptions().Parameter(username).Parameter(itemsPerPage).Parameter((page - 1) * itemsPerPage)
            );

            if (itemsQueryResult.MetaData.Status != QueryStatus.Success)
            {
                return null;
            }

            return await itemsQueryResult.Rows.ToListAsync();
        }

        public async Task<ToDoItem> CreateItem(string username, string title, string description)
        {
            var toDoItem = new ToDoItem
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                IsDone = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Creator = await _userService.GetUser(username)
            };

            try
            {
                await _couchbaseService.ToDoCollection.InsertAsync(
                    $"todoitem::{toDoItem.Id}", toDoItem, new InsertOptions());
            }
            catch
            {
                return null;
            }

            return toDoItem;
        }

        public async Task<bool> DeleteItem(Guid toDoItemId)
        {
            try
            {
                await _couchbaseService.ToDoCollection.RemoveAsync(
                    $"todoitem::{toDoItemId}", new RemoveOptions());
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateItem(ToDoItem toDoItem)
        {
            try
            {
                await _couchbaseService.ToDoCollection.ReplaceAsync(
                    $"todoitem::{toDoItem.Id}", toDoItem, new ReplaceOptions());
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
