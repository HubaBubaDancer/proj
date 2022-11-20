using AutoMapper;
using proj.Data.Handlers;
using proj.Models;

namespace proj.Data.Modules;

public class ProviderProfile : Profile
{
    public ProviderProfile()
    {

        CreateMap<CreateProviderRequest, Provider>();

    }
}