﻿namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Resultado da busca por um produto.
/// </summary>
public class GetProductResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
}
