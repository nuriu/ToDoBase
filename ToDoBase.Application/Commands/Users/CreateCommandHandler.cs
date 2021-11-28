using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoBase.Core.Entities;
using ToDoBase.Persistence.Services;

namespace ToDoBase.Application.Commands.Users
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, User>
    {
        private readonly IUserService _userService;

        public CreateCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            if (await _userService.IsUserExists(request.Username))
            {
                // TODO: handle user conflict exception
            }

            return await _userService.CreateUser(request.Username, request.Password);
        }
    }
}
