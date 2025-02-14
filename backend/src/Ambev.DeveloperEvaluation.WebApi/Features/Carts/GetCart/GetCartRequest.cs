using System;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;

/// <summary>
/// Request model to retrieve a cart by ID.
/// </summary>
public class GetCartRequest : IRequest<GetCartResponse>
{
    /// <summary>
    /// The unique identifier of the cart.
    /// </summary>
    public Guid Id { get; set; }
}
