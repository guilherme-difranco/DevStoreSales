using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Comando para atualizar uma venda existente.
/// </summary>
public class UpdateSaleCommand : IRequest<UpdateSaleResult>
{
    public Guid Id { get; set; }
    public string SaleNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; } = DateTime.UtcNow;
    public string CustomerName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public string Branch { get; set; } = string.Empty;
    public bool IsCancelled { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new UpdateSaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
