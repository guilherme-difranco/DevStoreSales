namespace Ambev.DeveloperEvaluation.Application.Carts.CartItem;

/// <summary>
/// Resultado da adição de um item ao carrinho.
/// </summary>
public class AddCartItemResult
{
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
}
