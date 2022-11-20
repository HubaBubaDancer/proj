using System.Runtime.CompilerServices;
using AutoMapper;
using MediatR;
using proj.Models;

namespace proj.Data.Handlers;

public class CreateProductRequest : IRequest<Product>
{
    public Guid ProductsNom { get; set; }
    public int Amount { get; set; }
    public Guid Stock { get; set; }

    public CreateProductRequest(Guid productsNom, int amount, Guid stock)
    {
        ProductsNom = productsNom;
        Amount = amount;
        Stock = stock;
    }
}



public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, Product>
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public CreateProductRequestHandler(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Product> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        _context.Products.Add(product);
        _context.SaveChanges();

        return product;
    }
}