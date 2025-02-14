﻿using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Carts.CartItem;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Profile for mapping between Cart entity and GetCartResponse
/// </summary>
public class GetCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetCart operation
    /// </summary>
    public GetCartProfile()
    {
        CreateMap<Cart, GetCartResult>();
        CreateMap<Domain.Entities.CartItem, GetCartItemResult>();
    }
}

