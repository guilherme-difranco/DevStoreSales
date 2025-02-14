using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

/// <summary>
/// Comando para deletar um carrinho.
/// </summary>
public class DeleteCartCommand : IRequest<DeleteCartResponse>
{
    public Guid CartId { get; set; }

    public DeleteCartCommand(Guid cartId)
    {
        CartId = cartId;
    }
}
