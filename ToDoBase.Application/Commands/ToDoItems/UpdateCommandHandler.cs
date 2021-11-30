using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoBase.Core.Entities;
using ToDoBase.Core.Exceptions;
using ToDoBase.Core.Services;

namespace ToDoBase.Application.Commands.ToDoItems
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, ToDoItem>
    {
        private readonly IToDoItemService _toDoItemService;

        public UpdateCommandHandler(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        public async Task<ToDoItem> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var toDoItem = await _toDoItemService.GetItem(request.ItemId);

            if (toDoItem == null || toDoItem.Creator.Username != request.Username)
            {
                throw new ToDoItemNotFoundException(request.ItemId);
            }

            toDoItem.IsDone = request.IsDone;
            await _toDoItemService.UpdateItem(toDoItem);

            return toDoItem;
        }
    }
}
