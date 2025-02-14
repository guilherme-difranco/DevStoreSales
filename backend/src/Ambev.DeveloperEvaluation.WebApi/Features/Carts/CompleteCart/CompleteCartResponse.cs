namespace Ambev.DeveloperEvaluation.Application.Carts.CompleteCart
{
    public class CompleteCartResponse
    {
        public Guid CartId { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsCompleted { get; set; }
    }
}
