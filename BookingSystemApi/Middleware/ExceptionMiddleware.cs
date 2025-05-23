using System.Security.Authentication;
using System.Text.Json;
using BookingSystemApi.Exceptions;

namespace BookingSystemApi.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        context.Response.StatusCode = exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            BadRequestException => StatusCodes.Status400BadRequest,
            ConflictException => StatusCodes.Status409Conflict,
            ForbiddenException => StatusCodes.Status403Forbidden,
            InternalServerException => StatusCodes.Status500InternalServerError,
            UnauthorizedException => StatusCodes.Status401Unauthorized,
            InvalidCredentialException => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };
        
        return context.Response.WriteAsync(JsonSerializer.Serialize(new { message = exception.Message, code = context.Response.StatusCode }));
    }
}
