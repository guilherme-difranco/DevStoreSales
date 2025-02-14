using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.RemoveItem;

namespace Ambev.DeveloperEvaluation.Application.Carts.RemoveItem
{
    public class RemoveItemHandler : IRequestHandler<RemoveItemCommand, RemoveItemResponse>
    {
        private readonly ICartRepository _cartRepository;

        public RemoveItemHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<RemoveItemResponse> Handle(RemoveItemCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByIdAsync(request.CartId, cancellationToken);
            if (cart == null)
            {
                return new RemoveItemResponse
                {
                    Success = false,
                    Message = "Carrinho não encontrado."
                };
            }

            cart.RemoveItem(request.ProductId);
            await _cartRepository.UpdateAsync(cart, cancellationToken);

            return new RemoveItemResponse
            {
                Success = true,
                Message = "Item removido com sucesso."
            };
        }
    }
}
