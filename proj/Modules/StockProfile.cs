using AutoMapper;
using proj.Data.Handlers;
using proj.Models;

namespace proj.Data.Modules;

public class StockProfile : Profile
{
    public StockProfile()
    {
        CreateMap<CreateStockRequest, Stock>();
    }
}