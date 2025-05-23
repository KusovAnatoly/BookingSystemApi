namespace BookingSystemApi.Exceptions;

/// <summary>
/// Exception representing a 404 Not Found HTTP error.
/// </summary>
public class NotFoundException : HttpException
{
    public NotFoundException(string message) : base(message) { }
}