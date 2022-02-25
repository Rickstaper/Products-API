using AutoMapper;
using Products.Data.DataTransferObject;
using Products.Data.Models;

namespace Products_API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FridgeModel, FridgeModelDto>();

            CreateMap<Fridge, FridgeDto>();
            CreateMap<FridgeForUpdateDto, Fridge>();

            CreateMap<FridgeProduct, FridgeProductDto>();
            CreateMap<FridgeProductForCreationDto, FridgeProduct>();
            CreateMap<FridgeProductForUpdateDto, FridgeProduct>();

            CreateMap<Product, ProductDto>();
        }
    }
}
