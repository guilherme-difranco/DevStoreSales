using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Command for retrieving a sale by ID.
/// </summary>
public class GetSaleCommand : IRequest<GetSaleResult>
{
    public Guid SaleId { get; set; }
}
