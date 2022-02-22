using AutoMapper;
using Products.Data.DataTransferObject;
using Products.Data.Models;

namespace Products_API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fridge, FridgeDto>();
        }
    }
}
