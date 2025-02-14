using Ambev.DeveloperEvaluation.Application.Carts.CartItem;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Resultado da busca por um carrinho.
/// </summary>
public class GetCartResult
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public List<GetCartItemResult> Items { get; set; } = new List<GetCartItemResult>();
}
