using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.SaleItem;

/// <summary>
/// Manipulador para processar a remoção de um item de uma venda.
/// </summary>
public class RemoveSaleItemHandler : IRequestHandler<RemoveSaleItemCommand, bool>
{
    private readonly ISaleRepository _saleRepository;

    public RemoveSaleItemHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<bool> Handle(RemoveSaleItemCommand command, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(command.SaleId, cancellationToken);
        if (sale == null)
            throw new InvalidOperationException("Venda não encontrada.");

        var itemToRemove = sale.Items.FirstOrDefault(i => i.Id == command.ItemId);
        if (itemToRemove == null)
            return false;

        sale.RemoveItem(itemToRemove);
        await _saleRepository.UpdateAsync(sale, cancellationToken);

        return true;
    }
}
