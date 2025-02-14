using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Comando para atualizar um produto existente.
/// </summary>
public class UpdateProductCommand : IRequest<UpdateProductResult>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;

    public ValidationResultDetail Validate()
    {
        var validator = new UpdateProductValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
