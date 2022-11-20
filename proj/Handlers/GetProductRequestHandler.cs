using MediatR;
using proj.Models;

namespace proj.Data.Handlers;

public class GetProductRequest : IRequest<Product>
{
    public Guid Id { get; set; }

    public GetProductRequest(Guid id)
    {
        Id = id;
    }
}


public class GetProductRequestHandler : IRequestHandler<GetProductRequest, Product>
{
    private readonly ApplicationDbContext _context;

    public GetProductRequestHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(GetProductRequest request, CancellationToken cancellationToken)
    {
        var product = _context.Products.FirstOrDefault(s => s.Id == request.Id);
        return product;
    }
}