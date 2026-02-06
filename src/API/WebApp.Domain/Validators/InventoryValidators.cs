using FluentValidation;
using WebApp.Domain.Interfaces.Application.UseCases.Commands;
using WebApp.Domain.Interfaces.Application.UseCases.Queries;

namespace WebApp.Domain.Validators;

public class UpdateInventoryStockValidator : AbstractValidator<UpdateInventoryStockUseCase>
{
    public UpdateInventoryStockValidator()
    {
        RuleFor(x => x.ProductId)
            .IsGuid()
            .WithMessage("Product ID is required.");
    }
}

public class GetInventoryValidator : AbstractValidator<GetInventoryUseCase>
{
    public GetInventoryValidator()
    {
        RuleFor(x => x.ProductId)
            .IsGuid()
            .WithMessage("Product ID is required.");
    }
}