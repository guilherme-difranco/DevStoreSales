using Microsoft.Extensions.Logging;
using System;

namespace Ambev.DeveloperEvaluation.Application.Carts
{
    public class CartEventsLogger
    {
        private readonly ILogger<CartEventsLogger> _logger;

        public CartEventsLogger(ILogger<CartEventsLogger> logger)
        {
            _logger = logger;
        }

        public void LogSaleCreated(Guid cartId)
        {
            _logger.LogInformation("SaleCreatedEvent: Venda do carrinho {CartId} concluída.", cartId);
        }

        public void LogSaleModified(Guid cartId)
        {
            _logger.LogInformation("SaleModifiedEvent: Carrinho {CartId} foi atualizado.", cartId);
        }

        public void LogSaleCancelled(Guid cartId)
        {
            _logger.LogInformation("SaleCancelledEvent: Carrinho {CartId} foi cancelado.", cartId);
        }

        public void LogItemCancelled(Guid cartId, Guid productId)
        {
            _logger.LogInformation("ItemCancelledEvent: Produto {ProductId} foi removido do carrinho {CartId}.", productId, cartId);
        }
    }
}
