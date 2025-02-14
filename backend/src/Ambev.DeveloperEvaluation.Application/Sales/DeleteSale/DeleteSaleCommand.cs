using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Command for deleting a sale.
/// </summary>
public class DeleteSaleCommand : IRequest<DeleteSaleResponse>
{
    public Guid SaleId { get; set; }
}
