using AutoMapper;
using FluentValidation;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.SaleItem;

/// <summary>
/// Manipulador para processar a adição de um item à venda.
/// </summary>
public class AddSaleItemHandler : IRequestHandler<AddSaleItemCommand, AddSaleItemResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public AddSaleItemHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<AddSaleItemResult> Handle(AddSaleItemCommand command, CancellationToken cancellationToken)
    {
        var validator = new AddSaleItemValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await _saleRepository.GetByIdAsync(command.SaleId, cancellationToken);
        if (sale == null)
            throw new InvalidOperationException("Venda não encontrada.");

        var newItem = _mapper.Map<Domain.Entities.SaleItem>(command);
        sale.AddItem(newItem);

        await _saleRepository.UpdateAsync(sale, cancellationToken);

        return _mapper.Map<AddSaleItemResult>(newItem);
    }
}
