using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoBase.Core.Entities;
using ToDoBase.Core.Exceptions;
using ToDoBase.Core.Services;

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
                throw new UsernameConflictException(request.Username);
            }

            return await _userService.CreateUser(request.Username, request.Password);
        }
    }
}
