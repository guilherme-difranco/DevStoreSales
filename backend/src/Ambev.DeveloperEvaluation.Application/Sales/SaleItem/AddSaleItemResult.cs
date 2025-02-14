using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.SaleItem;

/// <summary>
/// Resultado da adição de um item à venda.
/// </summary>
public class AddSaleItemResult
{
    public Guid Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalItem { get; set; }
}
