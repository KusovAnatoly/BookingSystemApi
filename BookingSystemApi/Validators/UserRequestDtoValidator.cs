using BookingSystemApi.DTOs.Requests;
using FluentValidation;

namespace BookingSystemApi.Validators;

public class UserRequestDtoValidator : AbstractValidator<UserRequestDto>
{
    public UserRequestDtoValidator()
    {
        RuleFor(registrationModel =>  registrationModel.Email).EmailAddress();
        RuleFor(registrationModel =>  registrationModel.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(registrationModel =>  registrationModel.SecondName).NotEmpty().MinimumLength(2);
    }
}