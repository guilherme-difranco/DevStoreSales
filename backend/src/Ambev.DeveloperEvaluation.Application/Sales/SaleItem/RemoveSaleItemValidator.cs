using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.SaleItem;

/// <summary>
/// Validador para remoção de um item da venda.
/// </summary>
public class RemoveSaleItemValidator : AbstractValidator<RemoveSaleItemCommand>
{
    public RemoveSaleItemValidator()
    {
        RuleFor(command => command.SaleId).NotEmpty();
        RuleFor(command => command.ItemId).NotEmpty();
    }
}
