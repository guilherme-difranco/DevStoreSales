using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

public class FakeProductRepository : IProductRepository
{
    private readonly Dictionary<Guid, Product> _products = new();

    public void Add(Product product)
    {
        _products[product.Id] = product;
    }

    public Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(Guid productId, CancellationToken cancellationToken = default)
    {
        _products.TryGetValue(productId, out var product);
        return Task.FromResult(product);
    }

    public Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

}
