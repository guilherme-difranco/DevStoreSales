using System;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem
    {
        // Identificador principal (chave primária)
        public Guid Id { get; set; }

        // Chave estrangeira para a venda
        public Guid SaleId { get; set; }

        // Nome (ou código) do produto
        public string ProductName { get; set; } = string.Empty;

        // Quantidade
        public int Quantity { get; set; }

        // Preço Unitário
        public decimal UnitPrice { get; set; }

        // Valor total do item (aplicando desconto, se houver)
        public decimal TotalItem { get; private set; }

        // Relação com a Venda (propriedade de navegação)
        public required Sale Sale { get; set; }

        /// <summary>
        /// Aplica a regra de desconto por quantidade:
        /// - <4 itens  => sem desconto
        /// - 4..9      => 10%
        /// - 10..20    => 20%
        /// (Quantidade > 20 é barrada na Sale)
        /// </summary>
        public void CalculateTotal()
        {
            decimal subTotal = Quantity * UnitPrice;
            decimal discountPercent = 0;

            if (Quantity >= 4 && Quantity < 10)
            {
                discountPercent = 0.10m;
            }
            else if (Quantity >= 10 && Quantity <= 20)
            {
                discountPercent = 0.20m;
            }

            var discountValue = subTotal * discountPercent;
            TotalItem = subTotal - discountValue;
        }
    }
}
