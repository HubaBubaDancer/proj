using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proj.Data.Handlers;
using proj.Models;

namespace proj.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProviderController : Controller
{
     private IMediator _mediator;

     public ProviderController(IMediator mediator)
     {
          _mediator = mediator;
     }

     [HttpPost]
     public async Task<IActionResult> CreateProvider(CreateProviderRequest request)
     {
          var provider = _mediator.Send(request).Result;
          return Ok(provider);
     }

     [HttpGet]
     public async Task<ActionResult<List<Provider>>> GetProviders()
     {
          var providers = _mediator.Send(new GetProvidersRequest()).Result;
          return Ok(providers);
     }

     [HttpDelete]
     public async Task<IActionResult> DeleteProvider(DeleteProviderRequest request)
     {
          var provider = _mediator.Send(request);
          return Ok(provider);
     }


}