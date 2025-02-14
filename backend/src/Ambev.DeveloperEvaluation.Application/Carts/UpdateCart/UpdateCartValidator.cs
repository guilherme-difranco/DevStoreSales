using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Validador para atualização do carrinho.
/// </summary>
public class UpdateCartValidator : AbstractValidator<UpdateCartCommand>
{
    public UpdateCartValidator()
    {
        RuleFor(cart => cart.CartId).NotEmpty();
        RuleFor(cart => cart.Date).NotEmpty();
    }
}
