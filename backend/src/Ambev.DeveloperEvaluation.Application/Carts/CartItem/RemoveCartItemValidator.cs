using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CartItem;

/// <summary>
/// Validador para remover item do carrinho.
/// </summary>
public class RemoveCartItemValidator : AbstractValidator<RemoveCartItemCommand>
{
    public RemoveCartItemValidator()
    {
        RuleFor(cart => cart.CartId).NotEmpty();
        RuleFor(cart => cart.ProductId).NotEmpty();
    }
}
