using FluentValidation;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;

/// <summary>
/// Validator for DeleteCartRequest.
/// </summary>
public class DeleteCartRequestValidator : AbstractValidator<DeleteCartRequest>
{
    public DeleteCartRequestValidator()
    {
        RuleFor(request => request.Id)
            .NotEmpty().WithMessage("Cart ID is required.")
            .Must(id => id != Guid.Empty).WithMessage("Invalid Cart ID.");
    }
}
