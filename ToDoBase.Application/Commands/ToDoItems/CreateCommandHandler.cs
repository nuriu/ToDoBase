using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoBase.Core.Entities;
using ToDoBase.Core.Services;

namespace ToDoBase.Application.Commands.ToDoItems
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, ToDoItem>
    {
        private readonly IToDoItemService _toDoItemService;

        public CreateCommandHandler(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        public async Task<ToDoItem> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            return await _toDoItemService.CreateItem(request.Username, request.Title, request.Description);
        }
    }
}
