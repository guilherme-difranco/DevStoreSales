using Ambev.DeveloperEvaluation.WebApi.Features.Carts.RemoveItem;
using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Carts.RemoveItem
{
    public class RemoveItemCommand : IRequest<RemoveItemResponse>
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
    }
}
