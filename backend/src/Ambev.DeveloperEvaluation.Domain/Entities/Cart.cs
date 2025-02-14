using Ambev.DeveloperEvaluation.Domain.Common;

using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Domain.Entities;
public class Cart : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid BranchId { get; set; } // referência à loja onde foi feita a venda
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public bool IsCompleted { get; private set; } = false;
    public bool IsCancelled { get; private set; } = false; // Identifica cancelamento
    public decimal TotalPrice { get; private set; } = 0;

    public List<CartItem> Items { get; set; } = new List<CartItem>();

    public void AddItem(Guid productId, int quantity, decimal unitPrice)
    {
        if (quantity <= 0)
            throw new Exception("Quantidade deve ser maior que zero.");

        var existing = Items.FirstOrDefault(i => i.ProductId == productId);
        if (existing != null)
        {
            existing.Quantity += quantity;
            existing.TotalAmount += unitPrice * quantity;
        }
        else
        {
            decimal totalAmount = unitPrice * quantity;
            decimal discount = 0;

            if (quantity >= 10 && quantity <= 20)
                discount = 0.2m;
            else if (quantity >= 4)
                discount = 0.1m;

            totalAmount -= totalAmount * discount;

            Items.Add(new CartItem
            {
                ProductId = productId,
                Quantity = quantity,
                UnitPrice = unitPrice,
                Discount = discount,
                TotalAmount = totalAmount
            });
        }
    }
    public void RemoveItem(Guid productId)
    {
        var item = Items.FirstOrDefault(i => i.ProductId == productId);
        if (item != null)
        {
            Items.Remove(item);
        }
    }
    public async Task CompleteCart(IProductRepository productRepository)
    {
        if (IsCompleted)
            throw new Exception("O carrinho já foi finalizado.");

        decimal total = 0;

        foreach (var item in Items)
        {
            var product = await productRepository.GetByIdAsync(item.ProductId);
            if (product == null)
                throw new Exception($"Produto {item.ProductId} não encontrado.");

            if (item.Quantity > 20)
                throw new Exception("Não é possível comprar mais de 20 unidades do mesmo produto.");

            total += item.TotalAmount;
        }

        TotalPrice = total;
        IsCompleted = true;
    }

    public void CancelCart()
    {
        if (IsCancelled)
            throw new Exception("Este carrinho já foi cancelado.");

        IsCancelled = true;
    }
}
