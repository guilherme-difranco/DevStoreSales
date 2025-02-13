using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public Guid UserId { get; set; }          // referência ao User
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(Guid productId, int quantity)
        {
            if (quantity <= 0)
                throw new Exception("Quantidade deve ser maior que zero.");

            var existing = Items.FirstOrDefault(i => i.ProductId == productId);
            if (existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity
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
    }
}
