using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.SaleItem;

/// <summary>
/// Comando para adicionar um item a uma venda existente.
/// </summary>
public class AddSaleItemCommand : IRequest<AddSaleItemResult>
{
    public Guid SaleId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new AddSaleItemValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
