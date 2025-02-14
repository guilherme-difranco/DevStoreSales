using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

/// <summary>
/// Validador para deletar um produto.
/// </summary>
public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
    }
}
