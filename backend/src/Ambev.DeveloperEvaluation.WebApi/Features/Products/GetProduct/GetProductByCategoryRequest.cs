namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// Request para obter produtos por categoria.
/// </summary>
public class GetProductByCategoryRequest
{
    public string Category { get; set; } = string.Empty;
}
