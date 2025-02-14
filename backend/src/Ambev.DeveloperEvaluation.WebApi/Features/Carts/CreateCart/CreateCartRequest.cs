using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// Representa a requisição para criação de um carrinho.
/// </summary>
public class CreateCartRequest
{
    /// <summary>
    /// ID do usuário associado ao carrinho.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// ID da filial onde a venda foi realizada.
    /// </summary>
    public Guid BranchId { get; set; }

    /// <summary>
    /// Data da criação do carrinho.
    /// </summary>
    public DateTime? Date { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Lista de produtos adicionados ao carrinho.
    /// </summary>
    public List<CreateCartItemRequest> Items { get; set; } = new List<CreateCartItemRequest>();
}

/// <summary>
/// Representa um item dentro do carrinho.
/// </summary>
public class CreateCartItemRequest
{
    /// <summary>
    /// ID do produto adicionado ao carrinho.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Quantidade do produto no carrinho.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Preço unitário do produto.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Desconto aplicado ao item.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Valor total do item considerando desconto.
    /// </summary>
    public decimal TotalAmount { get; set; }
}
