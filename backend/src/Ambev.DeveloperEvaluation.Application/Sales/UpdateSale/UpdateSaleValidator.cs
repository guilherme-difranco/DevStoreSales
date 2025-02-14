using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Validador para atualização de vendas.
/// </summary>
public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
{
    public UpdateSaleValidator()
    {
        RuleFor(sale => sale.SaleNumber).NotEmpty().MaximumLength(20);
        RuleFor(sale => sale.CustomerName).NotEmpty().MaximumLength(100);
        RuleFor(sale => sale.TotalAmount).GreaterThanOrEqualTo(0);
        RuleFor(sale => sale.Branch).NotEmpty().MaximumLength(50);
    }
}
