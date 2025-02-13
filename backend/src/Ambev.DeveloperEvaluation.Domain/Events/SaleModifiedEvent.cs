using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleModifiedEvent : IDomainEvent
    {
        public Sale Sale { get; }

        public SaleModifiedEvent(Sale sale)
        {
            Sale = sale;
        }
    }
}
