using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Carts.CartItem;

/// <summary>
/// Comando para adicionar um item ao carrinho.
/// </summary>
public class AddCartItemCommand : IRequest<AddCartItemResult>
{
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new AddCartItemValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
