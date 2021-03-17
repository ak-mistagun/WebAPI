using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPI.Services.Exceptions;

namespace WebAPI.Controllers.Filters
{
    public class TopicNotFoundExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is TopicNotFoundException ex)
            {
                context.Result = new ContentResult
                {
                    Content = ex.Message,
                    ContentType = "application/json",
                    StatusCode = 404
                };
            }
        }
    }
}