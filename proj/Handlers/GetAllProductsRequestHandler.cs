using MediatR;
using proj.Models;

namespace proj.Data.Handlers;

public class GetAllProductsRequest : IRequest<List<Product>>
{
}

public class GetAllProductsRequestHandler : IRequestHandler<GetAllProductsRequest, List<Product>>
{
    private readonly ApplicationDbContext _context;

    public GetAllProductsRequestHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        var products = _context.Products.ToList();
        return products;
    }
}