using FluentValidation;
using WebApp.Domain.Interfaces.Application.UseCases.Commands;

namespace WebApp.Domain.Validators;

public class RegisterClientValidator : AbstractValidator<RegisterClientUseCase>
{
    public RegisterClientValidator()
    {
        RuleFor(x => x.Request)
            .NotNull()
            .WithMessage("Client cannot be null.");

        RuleFor(x => x.Request!.Name)
            .NotEmpty()
            .WithMessage("Client name is required.");

        RuleFor(x => x.Request!.Email)
            .NotEmpty()
            .WithMessage("Valid email is required.")
            .EmailAddress()
            .WithMessage("A valid email is required");

        RuleFor(x => x.Request!.Phone)
            .NotEmpty()
            .WithMessage("Phone number is required.");
    }
}