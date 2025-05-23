namespace BookingSystemApi.Exceptions;

/// <summary>
/// Exception representing a 401 Unauthorized HTTP error.
/// </summary>
public class UnauthorizedException : HttpException
{
    public UnauthorizedException(string message) : base(message) { }
}