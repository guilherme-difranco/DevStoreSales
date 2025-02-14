using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CompleteCart
{
    public class CompleteCartRequest : IRequest<CompleteCartResponse>
    {
        public Guid Id { get; set; }
    }
}
