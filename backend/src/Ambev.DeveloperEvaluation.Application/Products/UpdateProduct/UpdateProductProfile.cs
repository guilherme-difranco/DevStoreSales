using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Profile para mapeamento entre entidade Produto e UpdateProductResult.
/// </summary>
public class UpdateProductProfile : Profile
{
    public UpdateProductProfile()
    {
        CreateMap<UpdateProductCommand, Product>();
        CreateMap<Product, UpdateProductResult>();
    }
}
