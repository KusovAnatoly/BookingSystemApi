namespace BookingSystemApi.Exceptions;

/// <summary>
/// Exception representing a 400 Bad Request HTTP error.
/// </summary>
public class BadRequestException : HttpException
{
    public BadRequestException(string message) : base(message) { }
}