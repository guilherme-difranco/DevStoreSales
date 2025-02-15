﻿using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts.CartItem;

/// <summary>
/// Handler para adicionar um item ao carrinho.
/// </summary>
public class AddCartItemHandler : IRequestHandler<AddCartItemCommand, AddCartItemResult>
{
    private readonly ICartRepository _cartRepository;
    IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public AddCartItemHandler(ICartRepository cartRepository, IProductRepository  productRepository,IMapper mapper)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<AddCartItemResult> Handle(AddCartItemCommand command, CancellationToken cancellationToken)
    {
        var validator = new AddCartItemValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = await _cartRepository.GetByIdAsync(command.CartId, cancellationToken);
        if (cart == null)
            throw new InvalidOperationException("O carrinho não foi encontrado.");

        var product = await _productRepository.GetByIdAsync(command.ProductId, cancellationToken);
        if (product == null)
            throw new Exception("Produto não encontrado.");

        cart.AddItem(command.ProductId, command.Quantity, product.Price);
        await _cartRepository.UpdateAsync(cart, cancellationToken);

        return new AddCartItemResult { CartId = cart.Id };
    }
}
