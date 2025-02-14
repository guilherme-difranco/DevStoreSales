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
    private readonly CartEventsLogger _eventLogger;

    public UpdateCartHandler(ICartRepository cartRepository, IMapper mapper, CartEventsLogger eventLogger)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
        _eventLogger = eventLogger;
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

        _eventLogger.LogSaleModified(cart.Id);

        await _cartRepository.UpdateAsync(cart, cancellationToken);

        return _mapper.Map<UpdateCartResult>(cart);
    }
}
