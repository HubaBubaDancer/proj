using AutoMapper;
using MediatR;
using proj.Models;

namespace proj.Data.Handlers;

public class CreateProductNOMRequest : IRequest<ProductsNOM>
{
    public string Name { get; set; }

    public double Price { get; set; }

    public string  UnitOfMeasurement { get; set; }

    public float Amount { get; set; }
    public string? Description { get; set; }

    public CreateProductNOMRequest(string name, double price, string unitOfMeasurement, float amount, string? description)
    {
        Name = name;
        Price = price;
        UnitOfMeasurement = unitOfMeasurement;
        Amount = amount;
        Description = description;
    }
}


public class CreateProductNOMRequestHandler : IRequestHandler<CreateProductNOMRequest, ProductsNOM>
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public CreateProductNOMRequestHandler(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ProductsNOM> Handle(CreateProductNOMRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<ProductsNOM>(request);
        _context.ProductsNOMs.Add(product);
        _context.SaveChanges();
        return product;
    }
}