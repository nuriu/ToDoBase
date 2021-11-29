using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoBase.Core.Entities;

namespace ToDoBase.Core.Services
{
    public interface IToDoItemService
    {
        Task<List<ToDoItem>> ListItems(string username, int page, int itemsPerPage);
        Task<ToDoItem> GetItem(Guid toDoItemId);
        Task<ToDoItem> CreateItem(string username, string title, string description);
        Task<bool> UpdateItem(ToDoItem toDoItem);
        Task<bool> DeleteItem(Guid toDoItemId);
    }
}
