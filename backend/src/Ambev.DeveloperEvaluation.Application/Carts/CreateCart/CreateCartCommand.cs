using Ambev.DeveloperEvaluation.Application.Carts.CartItem;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Comando para criar um carrinho.
/// </summary>
public class CreateCartCommand : IRequest<CreateCartResult>
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public List<AddCartItemCommand> Items { get; set; } = new List<AddCartItemCommand>();

    public ValidationResultDetail Validate()
    {
        var validator = new CreateCartValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
