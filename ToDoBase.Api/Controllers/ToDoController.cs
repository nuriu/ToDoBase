using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDoBase.Api.Filters;
using ToDoBase.Application.Commands.ToDoItems;
using ToDoBase.Application.Queries.ToDoItems;
using ToDoBase.Core.Entities;

namespace ToDoBase.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ExceptionFilter]
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        protected readonly IMediator _mediator;
        private readonly ILogger<ToDoController> _logger;

        public ToDoController(ILogger<ToDoController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ToDoItem), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<List<ToDoItem>> Get([FromQuery] ListQuery query)
        {
            query.Username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await _mediator.Send(query);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ToDoItem), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<ToDoItem> Post([FromBody] CreateCommand data)
        {
            data.Username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await _mediator.Send(data);
        }

    }
}
