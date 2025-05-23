namespace BookingSystemApi.Exceptions;

/// <summary>
/// Exception representing a 409 Conflict HTTP error.
/// </summary>
public class ConflictException  : HttpException
{
    public ConflictException (string message) : base(message) { }
}