using MediatR;
using Microsoft.AspNetCore.Mvc;
using proj.Data.Handlers;
using proj.Models;

namespace proj.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockController : Controller
{

    private IMediator _mediator;

    public StockController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<Stock> CreateStock(CreateStockRequest request)
    {
        var stock = await _mediator.Send(request);

        return stock;
    }

    [HttpGet("get-all")]
    public async Task<ActionResult<List<Stock>>> GetStocks()
    {
        var stocks = _mediator.Send(new GetStocksRequest()).Result;
        return stocks;
    }

    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetStock(GetStockRequest request)
    {
        var stock = _mediator.Send(request).Result;
        return Ok(stock);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteStock(DeleteStockRequest request)
    {
        var stock = _mediator.Send(request);
        return Ok(stock);
    }




}