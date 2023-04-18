using InSharpAssessment.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InSharpAssessment.WebAPI.Infrastructure.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is ApiException exception)
            {
                context.Result = new ObjectResult(exception.AppExceptionResult)
                {
                    StatusCode = (int)exception.HttpStatusCode,
                };
                context.ExceptionHandled = true;
            }
            else if (context.Exception is Exception ex)
            {
                var serverError = new ServerErrorException(ex);

                context.Result = new ObjectResult(serverError.AppExceptionResult)
                {
                    StatusCode = (int)serverError.HttpStatusCode
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
