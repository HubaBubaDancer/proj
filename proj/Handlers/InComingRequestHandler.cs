using System.Reflection.Metadata;
using AutoMapper;
using MediatR;
using proj.Models;

namespace proj.Data.Handlers;

public class InComingRequest : IRequest<DocumentModel>
{
    public string InvoiceNumber { get; set; }
    public Guid Provider { get; set; }
    public Guid Stock { get; set; }
    public IEnumerable<ProductDto> Products { get; set; }

    public InComingRequest(string invoiceNumber, Guid provider, Guid stock, IEnumerable<ProductDto> products)
    {
        InvoiceNumber = invoiceNumber;
        Provider = provider;
        Stock = stock;
        Products = products;
    }
}


public class InComingRequestHandler : RequestHandler<InComingRequest, DocumentModel>
{
    private ApplicationDbContext _context;
    private IMapper _mapper;

    public InComingRequestHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    protected override DocumentModel Handle(InComingRequest request)
    {
        var result = _mapper.Map<DocumentModel>(request);
        double sum = 0;
        foreach (var product in request.Products)
        {
            var price = _context.ProductsNOMs.FirstOrDefault(x => x.Id == product.ProductsNom).Price;
            sum += product.Amount * price;
        }
        result.Sum = sum;

        var products = request.Products.Select(product => _mapper.Map<Product>(product)).ToList();
        foreach (var product in products)
        {
            product.Stock = request.Stock;
        }
        
        _context.Products.AddRange(products);
        _context.DocumentModels.Add(result);
        _context.SaveChanges();
        return result;
    }
}