using System.Runtime.CompilerServices;
using AutoMapper;
using MediatR;
using proj.Models;

namespace proj.Data.Handlers;


public class GetProvidersRequest : IRequest<List<Provider>>
{
    
}

public class GetProvidersRequestHandler : IRequestHandler<GetProvidersRequest, List<Provider>>
{
    private readonly ApplicationDbContext _context;

    public GetProvidersRequestHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    
    public async Task<List<Provider>> Handle(GetProvidersRequest request, CancellationToken cancellationToken)
    {
        var providers = _context.Providers.ToList();

        return providers;
    }
}