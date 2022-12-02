using MediatR;
using Microsoft.AspNetCore.Mvc;
using proj.Data.Handlers;
using proj.Models;

namespace proj.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsInStockController : Controller
{
    private IMediator _mediator;

    public ProductsInStockController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<Product> CreateProduct(CreateProductRequest request)
    {
        var product = await _mediator.Send(request);
        return product;
    }

    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetProduct([FromQuery] Guid id)
    {
        var product = _mediator.Send(new GetProductRequest(id)).Result;
        return Ok(product);
    }

    [HttpGet("get-in-stock")]
    public async Task<ActionResult<List<Product>>> GetProductsByStockId([FromQuery] Guid StockId)
    {
        var products = _mediator.Send(new GetProductsByStockIdRequest(StockId)).Result;
        return Ok(products);
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = _mediator.Send(new GetAllProductsRequest()).Result;
        return Ok(products);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductAmount(UpdateProductAmountRequest request)
    {
        var product = _mediator.Send(request).Result;
        return Ok(product);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(DeleteProductRequest request)
    {
        var product = _mediator.Send(request).Result;
        return Ok(product);
    }




}