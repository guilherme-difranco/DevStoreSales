using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.SaleItem;

/// <summary>
/// Validador para adicionar um item à venda.
/// </summary>
public class AddSaleItemValidator : AbstractValidator<AddSaleItemCommand>
{
    public AddSaleItemValidator()
    {
        RuleFor(item => item.SaleId).NotEmpty();
        RuleFor(item => item.ProductName).NotEmpty().MaximumLength(100);
        RuleFor(item => item.Quantity).GreaterThan(0).LessThanOrEqualTo(20);
        RuleFor(item => item.UnitPrice).GreaterThan(0);
        RuleFor(item => item.Discount).GreaterThanOrEqualTo(0);
    }
}
