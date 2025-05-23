namespace BookingSystemApi.Exceptions;

/// <summary>
/// Exception representing a 403 Forbidden HTTP error.
/// </summary>
public class ForbiddenException  : HttpException
{
    public ForbiddenException (string message) : base(message) { }
}