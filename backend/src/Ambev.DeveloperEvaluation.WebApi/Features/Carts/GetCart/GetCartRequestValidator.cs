using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;

/// <summary>
/// Validator for GetCartRequest.
/// </summary>
public class GetCartRequestValidator : AbstractValidator<GetCartRequest>
{
    public GetCartRequestValidator()
    {
        RuleFor(request => request.Id)
            .NotEmpty().WithMessage("Cart ID is required.");
    }
}
