using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class UpdateCartRequestProfile : Profile
{
    public UpdateCartRequestProfile()
    {
        CreateMap<UpdateCartCommand, UpdateCartCommand>();
    }
}
