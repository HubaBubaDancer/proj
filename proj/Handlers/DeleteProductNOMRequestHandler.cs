using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using proj.Models;

namespace proj.Data.Handlers;


public class DeleteProductNOMRequest : IRequest<ProductsNOM>
{
    public Guid Id { get; set; }

    public DeleteProductNOMRequest(Guid id)
    {
        Id = id;
    }
}


public class DeleteProductNOMRequestHandler : IRequestHandler<DeleteProductNOMRequest, ProductsNOM>
{
    public readonly ApplicationDbContext _context;
    public readonly IMapper _mapper;
 
    public DeleteProductNOMRequestHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = _mapper;
    }

    public async Task<ProductsNOM> Handle(DeleteProductNOMRequest request, CancellationToken cancellationToken)
    {
        var product = _context.ProductsNOMs.FirstOrDefault(s => s.Id == request.Id);
        _context.ProductsNOMs.Remove(product);
        _context.SaveChanges();
        return product;
    }
}