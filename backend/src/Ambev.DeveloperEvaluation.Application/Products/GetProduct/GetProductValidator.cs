using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Validador para buscar um produto.
/// </summary>
public class GetProductValidator : AbstractValidator<GetProductCommand>
{
    public GetProductValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
    }
}
