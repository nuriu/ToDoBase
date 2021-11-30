using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Mime;
using System.Threading.Tasks;
using ToDoBase.Api.Filters;
using ToDoBase.Application.Commands.Users;
using ToDoBase.Core.Entities;
using ToDoBase.Core.Exceptions;

namespace ToDoBase.Api.Controllers
{
    [ExceptionFilter]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(UsernameConflictException), 401)]
        public async Task<User> Post([FromBody] CreateCommand data)
        {
            return await _mediator.Send(data);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(UserNotFoundException), 404)]
        public async Task<string> Token([FromBody] AuthorizeCommand query)
        {
            return await _mediator.Send(query);
        }
    }
}
