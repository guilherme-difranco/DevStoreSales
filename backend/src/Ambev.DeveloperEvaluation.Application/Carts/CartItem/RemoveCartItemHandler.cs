using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts.CartItem;

/// <summary>
/// Handler para remover item do carrinho.
/// </summary>
public class RemoveCartItemHandler : IRequestHandler<RemoveCartItemCommand, bool>
{
    private readonly ICartRepository _cartRepository;

    public RemoveCartItemHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<bool> Handle(RemoveCartItemCommand command, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByIdAsync(command.CartId, cancellationToken);
        if (cart == null)
            throw new InvalidOperationException("Carrinho não encontrado.");

        cart.RemoveItem(command.ProductId);
        await _cartRepository.UpdateAsync(cart, cancellationToken);

        return true;
    }
}
