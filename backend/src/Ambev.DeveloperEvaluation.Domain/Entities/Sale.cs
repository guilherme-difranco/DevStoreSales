using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public string SaleNumber { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalAmount { get; private set; }
        public string Branch { get; set; } = string.Empty;
        public bool IsCancelled { get; private set; }

        public List<SaleItem> Items { get; private set; } = new List<SaleItem>();

        public void AddItem(SaleItem item)
        {
            if (item.Quantity > 20)
            {
                throw new DomainException("Não é permitido vender mais de 20 unidades do mesmo produto.");
            }
            item.CalculateTotal();
            Items.Add(item);
            RecalculateTotal();
        }

        public void RemoveItem(SaleItem item)
        {
            Items.Remove(item);
            RecalculateTotal();
        }

        public void Cancel()
        {
            IsCancelled = true;
        }

        public void RecalculateTotal()
        {
            TotalAmount = Items.Sum(i => i.TotalItem);
        }
    }     
}
