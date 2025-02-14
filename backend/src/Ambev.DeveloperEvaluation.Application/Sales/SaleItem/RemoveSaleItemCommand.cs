using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.SaleItem;

/// <summary>
/// Comando para remover um item de uma venda.
/// </summary>
public class RemoveSaleItemCommand : IRequest<bool>
{
    public Guid SaleId { get; set; }
    public Guid ItemId { get; set; }
}
