using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoBase.Core.Entities;
using ToDoBase.Core.Services;

namespace ToDoBase.Application.Queries.ToDoItems
{
    public class ListQueryHandler : IRequestHandler<ListQuery, List<ToDoItem>>
    {
        private readonly IToDoItemService _toDoItemService;

        public ListQueryHandler(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        public async Task<List<ToDoItem>> Handle(ListQuery request, CancellationToken cancellationToken)
        {
            return await _toDoItemService.ListItems(request.Username, request.Page, request.ItemsPerPage);
        }
    }
}
