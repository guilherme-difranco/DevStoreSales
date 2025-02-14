using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.Application.Carts.RemoveItem;
using Ambev.DeveloperEvaluation.Application.Carts.CompleteCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts;

[ApiController]
[Route("api/[controller]")]
public class CartsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CartsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new cart.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCartResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCart([FromBody] CreateCartRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateCartRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateCartCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateCartResponse>
        {
            Success = true,
            Message = "Cart created successfully",
            Data = _mapper.Map<CreateCartResponse>(response)
        });
    }

    /// <summary>
    /// Retrieves a cart by ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCart([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetCartRequest { Id = id };
        var command = _mapper.Map<GetCartCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetCartResponse>
        {
            Success = true,
            Message = "Cart retrieved successfully",
            Data = _mapper.Map<GetCartResponse>(response)
        });
    }

    /// <summary>
    /// Updates a cart by ID.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCart([FromRoute] Guid id, [FromBody] UpdateCartCommand request, CancellationToken cancellationToken)
    {
        if (id != request.CartId)
            return BadRequest(new ApiResponse { Success = false, Message = "Cart ID mismatch" });

        var command = _mapper.Map<UpdateCartCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<UpdateCartResult>
        {
            Success = true,
            Message = "Cart updated successfully",
            Data = _mapper.Map<UpdateCartResult>(response)
        });
    }

    /// <summary>
    /// Deletes a cart by ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCart([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteCartRequest { Id = id };
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Cart deleted successfully"
        });
    }

    /// <summary>
    /// Removes an item from the cart.
    /// </summary>
    [HttpDelete("{cartId}/items/{productId}")]
    public async Task<IActionResult> RemoveItem([FromRoute] Guid cartId, [FromRoute] Guid productId, CancellationToken cancellationToken)
    {
        var command = new RemoveItemCommand { CartId = cartId, ProductId = productId };
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Item removed successfully"
        });
    }

    /// <summary>
    /// Completes a cart (checkout).
    /// </summary>
    [HttpPost("{id}/complete")]
    public async Task<IActionResult> CompleteCart([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new CompleteCartRequest { Id = id };
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<CompleteCartResponse>
        {
            Success = true,
            Message = "Cart completed successfully",
            Data = response
        });
    }
}
