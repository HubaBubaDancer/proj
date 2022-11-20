using MediatR;
using proj.Models;

namespace proj.Data.Handlers;


public class GetStocksRequest : IRequest<List<Stock>>
{
}


public class GetStocksRequestHandler : IRequestHandler<GetStocksRequest, List<Stock>>
{
    private readonly ApplicationDbContext _context;

    public GetStocksRequestHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Stock>> Handle(GetStocksRequest request, CancellationToken cancellationToken)
    {
        var stocks = _context.Stocks.ToList();
        return stocks;
    }
}