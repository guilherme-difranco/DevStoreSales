using Ambev.DeveloperEvaluation.Domain.Common;


namespace Ambev.DeveloperEvaluation.Domain.Entities;
public class CartItem : BaseEntity
{
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; } // Preço unitário
    public decimal Discount { get; set; } // Desconto aplicado
    public decimal TotalAmount { get; set; } // Total do item considerando o desconto

    public Cart? Cart { get; set; }
}
