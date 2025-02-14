using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.SaleItem;

/// <summary>
/// Response model for SaleItem within a sale
/// </summary>
public class GetSaleItemResult
{
    /// <summary>
    /// The unique identifier of the sale item
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The unique identifier of the product
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// The name of the product
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// The quantity of the product purchased
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The unit price of the product
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// The total discount applied
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// The total price after applying discounts
    /// </summary>
    public decimal TotalItem { get; set; }
}
