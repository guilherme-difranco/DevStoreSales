using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Manipulador para processar a atualização do carrinho.
/// </summary>
public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, UpdateCartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public UpdateCartHandler(ICartRepository cartRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    public async Task<UpdateCartResult> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCartValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = await _cartRepository.GetByIdAsync(request.CartId, cancellationToken);

        if (cart == null)
            throw new KeyNotFoundException("Cart not found.");

        cart.Date = request.Date;
        cart.Items.Clear();

        foreach (var item in request.Items)
        {
            cart.Items.Add(new Domain.Entities.CartItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity
            });
        }

        await _cartRepository.UpdateAsync(cart, cancellationToken);

        return _mapper.Map<UpdateCartResult>(cart);
    }
}
