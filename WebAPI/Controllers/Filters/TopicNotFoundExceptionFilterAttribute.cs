using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Controllers.Filters
{
    public class TopicNotFoundExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is Services.Exceptions.TopicNotFoundException ex)
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