using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.CartItem;

/// <summary>
/// Profile do AutoMapper para CartItem.
/// </summary>
public class CartItemProfile : Profile
{
    public CartItemProfile()
    {
        CreateMap<AddCartItemCommand, Domain.Entities.CartItem>();
        CreateMap<Domain.Entities.CartItem, AddCartItemResult>();
    }
}
