using Ambev.DeveloperEvaluation.Application.Sales.SaleItem;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Response model for GetSale operation
/// </summary>
public class GetSaleResult
{
    /// <summary>
    /// The unique identifier of the sale
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Sale number for tracking
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    /// The date the sale was created
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// The customer's name
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// The total amount of the sale
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// The branch where the sale was made
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// Indicates whether the sale is cancelled
    /// </summary>
    public bool IsCancelled { get; set; }

    /// <summary>
    /// List of items included in the sale
    /// </summary>
    public List<GetSaleItemResult> Items { get; set; } = new();
}
