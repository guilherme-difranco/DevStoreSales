using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

/// <summary>
/// Comando para deletar um produto.
/// </summary>
public class DeleteProductCommand : IRequest<DeleteProductResult>
{
    public Guid Id { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new DeleteProductValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    public DeleteProductCommand(Guid id)
    {
        Id = id;
    }
}
