using AutoMapper;
using proj.Data.Handlers;
using proj.Models;

namespace proj.Data.Modules;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        
        CreateMap<CreateProductNOMRequest, ProductsNOM>();

        CreateMap<CreateProductRequest, Product>();

        CreateMap<ProductDto, Product>();
    }
}