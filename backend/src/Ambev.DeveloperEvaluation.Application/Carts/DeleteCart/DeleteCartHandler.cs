using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

/// <summary>
/// Handler para deletar um carrinho.
/// </summary>
public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResponse>
{
    private readonly ICartRepository _cartRepository;

    public DeleteCartHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<DeleteCartResponse> Handle(DeleteCartCommand command, CancellationToken cancellationToken)
    {
        await _cartRepository.DeleteAsync(command.CartId, cancellationToken);
        return new DeleteCartResponse { Success = true };
    }
}
