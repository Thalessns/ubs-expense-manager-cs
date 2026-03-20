using Microsoft.AspNetCore.Diagnostics;
using UBS.Expense.Manager.Infra.Exceptions;

namespace UBS.Expense.Manager.API;

public record ErrorResponse(int statusCode, string message);

public class ExceptionHandler : IExceptionHandler
{
    private readonly ILogger<ExceptionHandler> _logger;

    public ExceptionHandler(ILogger<ExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        int statusCode = StatusCodes.Status500InternalServerError;
        if (exception is CustomException customEx)
        {
            statusCode = customEx.StatusCode;
        }
        var response = new { StatusCode = statusCode, Message = exception.Message };
        _logger.LogError(response.Message);
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
        return true;
    }
}