using Microsoft.AspNetCore.Http;

namespace Backend_Test.Infrastructure.Middleware
{
    public interface IExceptionHandler
    {
        ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken);
    }
}
