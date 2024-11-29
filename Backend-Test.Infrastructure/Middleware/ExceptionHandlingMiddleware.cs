using Microsoft.AspNetCore.Http;

namespace Backend_Test.Infrastructure.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionHandler _exceptionHandler;

        public ExceptionHandlingMiddleware(RequestDelegate next, IExceptionHandler exceptionHandler)
        {
            _next = next;
            _exceptionHandler = exceptionHandler;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) when (_exceptionHandler.TryHandleAsync(context, ex, CancellationToken.None).Result)
            {
                // Exception has been handled, do nothing further.
            }
        }
    }
}
