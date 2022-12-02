using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public Task<List<ProductsNOM>> GetAllProductNoMs()
        {
            var result = _mediator.Send(new GetProductNOMSRequest());
            
            return result;
        }

        [HttpPost("create-product-nom")]
        public Task<ProductsNOM> CreateProductNom(CreateProductNOMRequest request)
        {
            var result = _mediator.Send(request);
            return result;
        }

        [HttpDelete]
        public Task<ProductsNOM> DeleteProductNoM(DeleteProductNOMRequest request)
        {
            var result = _mediator.Send(request);
            return result;
        }
    }
}