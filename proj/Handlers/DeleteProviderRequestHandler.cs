using AutoMapper;
using MediatR;
using proj.Models;

namespace proj.Data.Handlers;

public class DeleteProviderRequest : IRequest<Provider>
{
    public Guid Id { get; set; }

    public DeleteProviderRequest(Guid id)
    {
        Id = id;
    }
}



public class DeleteProviderRequestHandler : IRequestHandler<DeleteProviderRequest, Provider>
{
    private readonly ApplicationDbContext _context;

    public DeleteProviderRequestHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Provider> Handle(DeleteProviderRequest request, CancellationToken cancellationToken)
    {
        var provider = _context.Providers.FirstOrDefault(s => s.Id == request.Id);
        _context.Providers.Remove(provider);
        _context.SaveChanges();
        
        return provider;
    }
}