using FluentValidation;
using WebApp.Domain.Interfaces.Application.UseCases.Commands;

namespace WebApp.Domain.Validators;

public class RegisterProductValidator : AbstractValidator<RegisterProductUseCase>
{
    public RegisterProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Product name is required.");
    }
}