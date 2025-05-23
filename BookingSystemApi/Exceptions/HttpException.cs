namespace BookingSystemApi.Exceptions;

/// <summary>
/// Base class for HTTP-related exceptions.
/// Use this as a parent for all custom HTTP exceptions to group them logically.
/// </summary>
public abstract class HttpException : Exception
{
    protected HttpException(string message) : base(message) {}
}