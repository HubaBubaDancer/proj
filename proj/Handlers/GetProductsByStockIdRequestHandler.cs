using MediatR;
using proj.Models;

namespace proj.Data.Handlers;

public class GetProductsByStockIdRequest : IRequest<List<Product>>
{
    public Guid StockId { get; set; }

    public GetProductsByStockIdRequest(Guid stockId)
    {
        StockId = stockId;
    }
}

public class GetProductsByStockIdRequestHandler : IRequestHandler<GetProductsByStockIdRequest, List<Product>>
{
    private readonly ApplicationDbContext _context;

    public GetProductsByStockIdRequestHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> Handle(GetProductsByStockIdRequest request, CancellationToken cancellationToken)
    {
        var products = _context.Products.Where(s => s.Stock == request.StockId).ToList();
        return products;
    }
}