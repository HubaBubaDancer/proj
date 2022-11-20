using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proj.Data.Handlers;
using proj.Models;

namespace proj.Controllers
{
    
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        private IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all-product-noms")]
        public async Task<ActionResult<List<ProductsNOM>>> GetAllProductNoMs()
        {
            var result = await _mediator.Send(new GetProductNOMSRequest());
            if (result.Any())
            {
                return result;
            }

            return BadRequest("Products don't exist");
        }

        [HttpPost("create-product-nom")]
        public async Task<IActionResult> CreateProductNom(CreateProductNOMRequest request)
        {
            var result = _mediator.Send(request).Result;
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductNoM(DeleteProductNOMRequest request)
        {
            var result = _mediator.Send(request);
            return Ok(result);
        }


    }
}