using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Validador para atualização do carrinho.
/// </summary>
public class UpdateProductRequestValidator : AbstractValidator<UpdateCartCommand>
{
    public UpdateProductRequestValidator()
    {
        RuleFor(cart => cart.CartId)
            .NotEmpty().WithMessage("Cart ID is required.");

        RuleFor(cart => cart.Items)
            .NotEmpty().WithMessage("At least one item is required.");
    }
}
