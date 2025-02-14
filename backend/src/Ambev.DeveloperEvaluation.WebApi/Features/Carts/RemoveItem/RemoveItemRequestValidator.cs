using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.RemoveItem
{
    public class RemoveItemRequestValidator : AbstractValidator<RemoveItemRequest>
    {
        public RemoveItemRequestValidator()
        {
            RuleFor(x => x.CartId)
                .NotEmpty().WithMessage("CartId é obrigatório.");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId é obrigatório.");
        }
    }
}
