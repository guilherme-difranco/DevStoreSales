namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Resultado da criação de um produto.
/// </summary>
public class CreateProductResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
