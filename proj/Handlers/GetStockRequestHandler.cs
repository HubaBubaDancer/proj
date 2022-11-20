using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using MediatR;
using proj.Models;

namespace proj.Data.Handlers;

public class GetStockRequest : IRequest<Stock>
{
    public Guid Id { get; set; }

    public GetStockRequest(Guid id)
    {
        Id = id;
    }
}

public class GetStockRequestHandler : IRequestHandler<GetStockRequest, Stock>
{
    private readonly ApplicationDbContext _context;

    public GetStockRequestHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Stock> Handle(GetStockRequest request, CancellationToken cancellationToken)
    {
        var stock = _context.Stocks.FirstOrDefault(s => s.Id == request.Id);
        return stock;
    }
}