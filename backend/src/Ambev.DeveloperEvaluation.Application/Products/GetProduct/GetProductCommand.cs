using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Comando para buscar um produto pelo ID.
/// </summary>
public class GetProductCommand : IRequest<GetProductResult>
{
    public Guid Id { get; set; }

    public GetProductCommand(Guid id)
    {
        Id = id;
    }
}
