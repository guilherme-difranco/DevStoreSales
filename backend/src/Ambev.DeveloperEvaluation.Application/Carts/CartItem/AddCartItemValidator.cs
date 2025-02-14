using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CartItem;

/// <summary>
/// Validador para adicionar um item ao carrinho.
/// </summary>
public class AddCartItemValidator : AbstractValidator<AddCartItemCommand>
{
    public AddCartItemValidator()
    {
        RuleFor(cart => cart.CartId).NotEmpty();
        RuleFor(cart => cart.ProductId).NotEmpty();
        RuleFor(cart => cart.Quantity).GreaterThan(0);
    }
}
