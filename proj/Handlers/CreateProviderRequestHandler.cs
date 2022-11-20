using AutoMapper;
using MediatR;
using proj.Models;

namespace proj.Data.Handlers;


public class CreateProviderRequest : IRequest<Provider>
{
    public string CompanyName { get; set; }
    
    public string FiscalCode { get; set; }
    
    public string Address { get; set; }
    
    public string Email { get; set; }
    
    public string Number { get; set; }

    public CreateProviderRequest(string companyName, string fiscalCode, string address, string email, string number)
    {
        CompanyName = companyName;
        FiscalCode = fiscalCode;
        Address = address;
        Email = email;
        Number = number;
    }
}


public class CreateProviderRequestHandler : IRequestHandler<CreateProviderRequest, Provider>
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public CreateProviderRequestHandler(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Provider> Handle(CreateProviderRequest request, CancellationToken cancellationToken)
    {
        var provider = _mapper.Map<Provider>(request);
        _context.Providers.Add(provider);
        _context.SaveChanges();
        
        return provider;
    }
}