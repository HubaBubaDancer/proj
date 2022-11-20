using AutoMapper;
using MediatR;
using proj.Models;

namespace proj.Data.Handlers;

public class UpdateProductAmountRequest : IRequest<Product>
{
    public Guid Id { get; set; }

    public int Amount { get; set; }

    public UpdateProductAmountRequest(Guid id, int amount)
    {
        Id = id;
        Amount = amount;
    }
}


public class UpdateProductAmountRequestHandler : IRequestHandler<UpdateProductAmountRequest, Product>
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public UpdateProductAmountRequestHandler(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Product> Handle(UpdateProductAmountRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        _context.Products.Update(product);
        _context.SaveChanges();
        return product;
    }
}