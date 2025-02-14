using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Comando para obter um carrinho.
/// </summary>
public class GetCartCommand : IRequest<GetCartResult>
{
    public Guid CartId { get; set; }

    public GetCartCommand(Guid cartId)
    {
        CartId = cartId;
    }
}
