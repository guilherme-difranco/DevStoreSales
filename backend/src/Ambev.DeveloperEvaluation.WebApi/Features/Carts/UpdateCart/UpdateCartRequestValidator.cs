using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Validador para atualização do carrinho.
/// </summary>
public class UpdateCartValidator : AbstractValidator<UpdateCartCommand>
{
    public UpdateCartValidator()
    {
        RuleFor(cart => cart.CartId)
            .NotEmpty().WithMessage("Cart ID is required.");

        RuleFor(cart => cart.BranchId)
            .NotEmpty().WithMessage("Branch ID is required."); //  Adicionando validação

        RuleFor(cart => cart.Items)
            .NotEmpty().WithMessage("At least one item is required.");

        RuleFor(cart => cart.TotalPrice)
            .GreaterThanOrEqualTo(0).WithMessage("Total price must be non-negative.");

        RuleFor(cart => cart.Date)
            .NotEmpty().WithMessage("Date is required.");
    }
}
