using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Representa o resultado da criação do carrinho.
/// </summary>
public class CreateCartResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BranchId { get; set; } //  Adicionando BranchId
    public DateTime Date { get; set; }
    public decimal TotalPrice { get; set; } //  Adicionando TotalPrice
    public bool IsCompleted { get; set; } //  Adicionando Status
    public bool IsCancelled { get; set; } //  Adicionando Status

    public List<CreateCartItemResponse> Items { get; set; } = new List<CreateCartItemResponse>();
}

/// <summary>
/// Representa um item no carrinho criado.
/// </summary>
public class CreateCartItemResponse
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; } //  Adicionando preço unitário
    public decimal Discount { get; set; } //  Adicionando desconto
    public decimal TotalAmount { get; set; } //  Adicionando total com desconto
}
