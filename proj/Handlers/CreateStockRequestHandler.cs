using System.Runtime.CompilerServices;
using AutoMapper;
using MediatR;
using proj.Models;

namespace proj.Data.Handlers;

public class CreateStockRequest : IRequest<Stock>
{
    public string Name { get; set; }

    public CreateStockRequest(string name)
    {
        Name = name;
    }
}



public class CreateStockRequestHandler : IRequestHandler<CreateStockRequest, Stock>
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public CreateStockRequestHandler(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Stock> Handle(CreateStockRequest request, CancellationToken cancellationToken)
    {
        var stock = _mapper.Map<Stock>(request);
        _context.Stocks.Add(stock);
        _context.SaveChanges();
        return stock;
    }
}