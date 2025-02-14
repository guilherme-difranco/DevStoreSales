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
    public DateTime Date { get; set; }
    public List<CreateCartItemResponse> Items { get; set; } = new List<CreateCartItemResponse>();
}

/// <summary>
/// Representa um item no carrinho criado.
/// </summary>
public class CreateCartItemResponse
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
