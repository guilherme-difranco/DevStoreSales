using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.RemoveItem
{
    public class RemoveItemRequest : IRequest<RemoveItemResponse>
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
    }
}
