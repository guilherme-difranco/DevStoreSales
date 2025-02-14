using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validador para criação de um novo produto.
/// </summary>
public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MaximumLength(100);
        RuleFor(p => p.Price).GreaterThan(0);
        RuleFor(p => p.Description).MaximumLength(500);
    }
}
