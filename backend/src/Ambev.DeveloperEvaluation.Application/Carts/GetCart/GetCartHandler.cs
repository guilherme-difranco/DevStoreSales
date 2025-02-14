using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Handler para obter um carrinho.
/// </summary>
public class GetCartHandler : IRequestHandler<GetCartCommand, GetCartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public GetCartHandler(ICartRepository cartRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    public async Task<GetCartResult> Handle(GetCartCommand command, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByIdAsync(command.CartId, cancellationToken);
        if (cart == null)
            throw new InvalidOperationException("Carrinho não encontrado.");

        return _mapper.Map<GetCartResult>(cart);
    }
}
