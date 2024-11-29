using Backend_Test.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Backend_Test.Infrastructure.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = new ProblemDetails
            {
                Instance = httpContext.Request.Path
            };

            if (exception is BaseException baseException)
            {
                httpContext.Response.StatusCode = (int)baseException.StatusCode;
                problemDetails.Title = baseException.Message;
                problemDetails.Status = (int)baseException.StatusCode;
            }
            else
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                problemDetails.Title = "An unexpected error occurred.";
                problemDetails.Status = (int)HttpStatusCode.InternalServerError;
            }

            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsync(
                JsonSerializer.Serialize(problemDetails),
                cancellationToken
            ).ConfigureAwait(false);

            return true;
        }
    }
}
