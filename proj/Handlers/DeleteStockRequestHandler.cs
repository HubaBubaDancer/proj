using System.Runtime.CompilerServices;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proj.Models;

namespace proj.Data.Handlers;

public class DeleteStockRequest : IRequest<Stock>
{
    public Guid Id { get; set; }

    public DeleteStockRequest(Guid id)
    {
        Id = id;
    }
}

public class DeleteStockRequestHandler : IRequestHandler<DeleteStockRequest, Stock>
{
    private readonly ApplicationDbContext _context;

    public DeleteStockRequestHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Stock> Handle(DeleteStockRequest request, CancellationToken cancellationToken)
    {
        var stock = _context.Stocks.FirstOrDefault(s => s.Id == request.Id);
        _context.Stocks.Remove(stock);
        _context.SaveChanges();
        
        return stock;
    }
}