using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CompleteCart
{
    public class CompleteCartValidator : AbstractValidator<CompleteCartRequest>
    {
        public CompleteCartValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Cart ID is required.");
        }
    }
}
