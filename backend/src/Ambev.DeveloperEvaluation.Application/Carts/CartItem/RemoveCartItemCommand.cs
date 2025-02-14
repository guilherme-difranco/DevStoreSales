using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Carts.CartItem;

/// <summary>
/// Comando para remover um item do carrinho.
/// </summary>
public class RemoveCartItemCommand : IRequest<bool>
{
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }

    public RemoveCartItemCommand(Guid cartId, Guid productId)
    {
        CartId = cartId;
        ProductId = productId;
    }
}
