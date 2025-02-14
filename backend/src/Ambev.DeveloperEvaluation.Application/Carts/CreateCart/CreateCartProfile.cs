using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Profile do AutoMapper para CreateCart.
/// </summary>
public class CreateCartProfile : Profile
{
    public CreateCartProfile()
    {
        CreateMap<UpdateCartCommand, Cart>();
        CreateMap<Cart, CreateCartResult>();
    }
}
