using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using ToDoBase.Core.Exceptions;

namespace ToDoBase.Api.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ToDoBaseBadRequestException:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case ToDoBaseNotFoundException:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    break;
            }

            context.Result = new JsonResult(new { context.Exception.Message });
            base.OnException(context);
        }
    }
}
