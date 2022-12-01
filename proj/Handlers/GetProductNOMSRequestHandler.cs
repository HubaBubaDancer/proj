using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using proj.Models;

namespace proj.Data.Handlers
{
    public class GetProductNOMSRequest : IRequest<List<ProductsNOM>>
    {
        public GetProductNOMSRequest()
        {
            
        }
    }


    public class GetProductNOMsRequestHandler : IRequestHandler<GetProductNOMSRequest, List<ProductsNOM>>
    {

        private readonly ApplicationDbContext _context;

        public GetProductNOMsRequestHandler(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<List<ProductsNOM>> Handle(GetProductNOMSRequest request, CancellationToken cancellationToken)
        {
            var products = _context.ProductsNOMs.ToList();
            return products;
        }
    }
}