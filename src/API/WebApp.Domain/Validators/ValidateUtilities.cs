using FluentValidation;

namespace WebApp.Domain.Validators;

public static class ValidateUtilities
{
    public static IRuleBuilderOptions<T, Guid> IsGuid<T>(this IRuleBuilder<T, Guid> builder)
        => builder.Must(x => x != Guid.Empty);
}