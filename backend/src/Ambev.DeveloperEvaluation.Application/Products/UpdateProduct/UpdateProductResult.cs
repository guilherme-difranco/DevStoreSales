namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Resultado da atualização de um produto.
/// </summary>
public class UpdateProductResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
}
