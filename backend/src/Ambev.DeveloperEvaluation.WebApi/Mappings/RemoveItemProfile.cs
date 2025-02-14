using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Carts.RemoveItem;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.RemoveItem;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class RemoveItemProfile : Profile
    {
        public RemoveItemProfile()
        {
            CreateMap<RemoveItemRequest, RemoveItemCommand>();
            CreateMap<RemoveItemResponse, RemoveItemResponse>();
        }
    }
}
