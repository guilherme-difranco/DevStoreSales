using Ambev.DeveloperEvaluation.Application.Carts.CompleteCart;
using Ambev.DeveloperEvaluation.Application.Carts;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class CompleteCartHandler : IRequestHandler<CompleteCartRequest, CompleteCartResponse>
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly CartEventsLogger _eventLogger;
    private readonly IMapper _mapper;

    public CompleteCartHandler(
        ICartRepository cartRepository,
        IProductRepository productRepository,
        CartEventsLogger eventLogger, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _eventLogger = eventLogger;
        _mapper = mapper;
    }

    public async Task<CompleteCartResponse> Handle(CompleteCartRequest request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByIdAsync(request.Id, cancellationToken);
        if (cart == null)
            throw new Exception("Carrinho não encontrado.");

        await cart.CompleteCart(_productRepository);
        await _cartRepository.UpdateAsync(cart, cancellationToken);

        _eventLogger.LogSaleCreated(cart.Id); // Registra o evento


        return _mapper.Map<CompleteCartResponse>(cart);
    }
}
