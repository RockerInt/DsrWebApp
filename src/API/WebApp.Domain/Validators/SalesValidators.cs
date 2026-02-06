using FluentValidation;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Application.UseCases.Commands;

namespace WebApp.Domain.Validators;

public class RegisterSaleValidator : AbstractValidator<RegisterSaleUseCase>
{
    public RegisterSaleValidator()
    {
        RuleFor(x => x.Request)
            .NotNull()
            .WithMessage("Sale cannot be null.");

        RuleFor(x => x.Request!.ClientId)
            .IsGuid()
            .WithMessage("Client ID is required.");

        RuleFor(x => x.Request!.Items)
            .NotNull()
            .WithMessage("Items cannot be null.")
            .Empty()
            .WithMessage("At least one item is required.")
            .ForEach(item => item.SetValidator(new SaleItemValidator()));
    }
}

public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(x => x.ProductId)
            .IsGuid()
            .WithMessage("Product ID is required.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than zero.");
    }
}