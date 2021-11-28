using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Mime;
using System.Threading.Tasks;
using ToDoBase.Api.Filters;
using ToDoBase.Application.Commands.Users;
using ToDoBase.Application.Queries.Users;
using ToDoBase.Core.Entities;

namespace ToDoBase.Api.Controllers
{
    [ExceptionFilter]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        protected readonly IMediator _mediator;
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
        public async Task<ActionResult<User>> Post([FromBody] CreateCommand data)
        {
            return await _mediator.Send(data);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<ActionResult<string>> Token([FromBody] AuthQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
