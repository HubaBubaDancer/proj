using MediatR;
using proj.Models;

namespace proj.Data.Handlers;


public class DeleteProductRequest : IRequest<Product>
{
    public Guid Id { get; set; }

    public DeleteProductRequest(Guid id)
    {
        Id = id;
    }
}

public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest, Product>
{
    private readonly ApplicationDbContext _context;

    public DeleteProductRequestHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        var product = _context.Products.FirstOrDefault(s => s.Id == request.Id);
        _context.Products.Remove(product);
        _context.SaveChanges();
        return product;
    }
}