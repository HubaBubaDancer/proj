using MediatR;
using Microsoft.AspNetCore.Mvc;
using proj.Data.Handlers;

namespace proj.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ActionsController : Controller
{
    IMediator _mediator;

    public ActionsController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> InComing(InComingRequest request)
    {
        var result = _mediator.Send(request).Result;
        return Ok(result);
    }
    
    
}