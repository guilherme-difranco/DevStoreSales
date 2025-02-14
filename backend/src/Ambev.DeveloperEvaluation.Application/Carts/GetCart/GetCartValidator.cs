using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Validador para buscar um carrinho.
/// </summary>
public class GetCartValidator : AbstractValidator<GetCartCommand>
{
    public GetCartValidator()
    {
        RuleFor(cart => cart.CartId).NotEmpty();
    }
}
