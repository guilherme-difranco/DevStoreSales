using Ambev.DeveloperEvaluation.Application.Carts.CartItem;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Comando para atualizar um carrinho.
/// </summary>
public class UpdateCartCommand : IRequest<UpdateCartResult>
{
    public Guid CartId { get; set; }
    public Guid BranchId { get; set; } //  Adicionando BranchId
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public decimal TotalPrice { get; set; } //  Adicionando TotalPrice
    public bool IsCompleted { get; set; } //  Adicionando Status
    public bool IsCancelled { get; set; } //  Adicionando Status
    public List<UpdateCartItemCommand> Items { get; set; } = new List<UpdateCartItemCommand>();

    public ValidationResultDetail Validate()
    {
        var validator = new UpdateCartValidator(); //  Corrigindo nome do validador
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
