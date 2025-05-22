namespace BookingSystemApi.DTOs.Requests;

public class UserSignInRequestDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}