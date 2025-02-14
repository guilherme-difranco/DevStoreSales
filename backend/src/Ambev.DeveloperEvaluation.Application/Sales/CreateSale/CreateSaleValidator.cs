using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for sale creation.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleCommandValidator()
    {
        RuleFor(sale => sale.SaleNumber).NotEmpty().Length(3, 50);
        RuleFor(sale => sale.CustomerName).NotEmpty().Length(3, 100);
        RuleFor(sale => sale.Branch).NotEmpty().Length(2, 50);
        RuleFor(sale => sale.Items)
            .NotEmpty().WithMessage("A sale must contain at least one item.");
    }
}
