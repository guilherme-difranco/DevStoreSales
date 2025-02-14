namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// Resposta para obtenção de produtos por categoria.
/// </summary>
public class GetProductByCategoryResponse
{
    public List<GetProductResponse> Data { get; set; } = new();
    public int TotalItems { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}
