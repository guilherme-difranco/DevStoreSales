﻿//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using AutoMapper;
//using Ambev.DeveloperEvaluation.WebApi.Common;
//using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
//using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
//using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
//using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
//using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
//using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
//using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;
//using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

//namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

///// <summary>
///// Controller for managing sales operations.
///// </summary>
//[ApiController]
//[Route("api/[controller]")]
//public class SalesController : BaseController
//{
//    private readonly IMediator _mediator;
//    private readonly IMapper _mapper;

//    /// <summary>
//    /// Initializes a new instance of SalesController.
//    /// </summary>
//    /// <param name="mediator">The mediator instance.</param>
//    /// <param name="mapper">The AutoMapper instance.</param>
//    public SalesController(IMediator mediator, IMapper mapper)
//    {
//        _mediator = mediator;
//        _mapper = mapper;
//    }

//    /// <summary>
//    /// Creates a new sale.
//    /// </summary>
//    [HttpPost]
//    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
//    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//    public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
//    {
//        var validator = new CreateSaleRequestValidator();
//        var validationResult = await validator.ValidateAsync(request, cancellationToken);

//        if (!validationResult.IsValid)
//            return BadRequest(validationResult.Errors);

//        var command = _mapper.Map<CreateSaleCommand>(request);
//        var response = await _mediator.Send(command, cancellationToken);

//        return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
//        {
//            Success = true,
//            Message = "Sale created successfully",
//            Data = _mapper.Map<CreateSaleResponse>(response)
//        });
//    }

//    /// <summary>
//    /// Retrieves a sale by ID.
//    /// </summary>
//    [HttpGet("{id}")]
//    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
//    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
//    public async Task<IActionResult> GetSale([FromRoute] Guid id, CancellationToken cancellationToken)
//    {
//        var request = new GetSaleRequest { Id = id };
//        var validator = new GetSaleRequestValidator();
//        var validationResult = await validator.ValidateAsync(request, cancellationToken);

//        if (!validationResult.IsValid)
//            return BadRequest(validationResult.Errors);

//        var command = _mapper.Map<GetSaleCommand>(request);
//        var response = await _mediator.Send(command, cancellationToken);

//        return Ok(new ApiResponseWithData<GetSaleResponse>
//        {
//            Success = true,
//            Message = "Sale retrieved successfully",
//            Data = _mapper.Map<GetSaleResponse>(response)
//        });
//    }

//    /// <summary>
//    /// Updates a sale by ID.
//    /// </summary>
//    [HttpPut("{id}")]
//    [ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleResult>), StatusCodes.Status200OK)]
//    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
//    public async Task<IActionResult> UpdateSale([FromRoute] Guid id, [FromBody] UpdateSaleRequest request, CancellationToken cancellationToken)
//    {
//        if (id != request.Id)
//            return BadRequest(new ApiResponse { Success = false, Message = "Sale ID mismatch" });

//        var validator = new UpdateSaleRequestValidator();
//        var validationResult = await validator.ValidateAsync(request, cancellationToken);

//        if (!validationResult.IsValid)
//            return BadRequest(validationResult.Errors);

//        var command = _mapper.Map<UpdateSaleCommand>(request);
//        var response = await _mediator.Send(command, cancellationToken);

//        return Ok(new ApiResponseWithData<UpdateSaleResult>
//        {
//            Success = true,
//            Message = "Sale updated successfully",
//            Data = _mapper.Map<UpdateSaleResult>(response)
//        });
//    }

//    /// <summary>
//    /// Deletes a sale by ID.
//    /// </summary>
//    [HttpDelete("{id}")]
//    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
//    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
//    public async Task<IActionResult> DeleteSale([FromRoute] Guid id, CancellationToken cancellationToken)
//    {
//        var command = new DeleteSaleCommand { Id = id };
//        await _mediator.Send(command, cancellationToken);

//        return Ok(new ApiResponse
//        {
//            Success = true,
//            Message = "Sale deleted successfully"
//        });
//    }
//}
