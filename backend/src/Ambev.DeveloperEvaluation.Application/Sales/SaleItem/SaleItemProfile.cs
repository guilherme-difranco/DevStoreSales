using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.SaleItem;

/// <summary>
/// Configuração do AutoMapper para conversão de SaleItem.
/// </summary>
public class SaleItemProfile : Profile
{
    public SaleItemProfile()
    {
        CreateMap<AddSaleItemCommand, Domain.Entities.SaleItem>();
        CreateMap<Domain.Entities.SaleItem, AddSaleItemResult>();
    }
}
