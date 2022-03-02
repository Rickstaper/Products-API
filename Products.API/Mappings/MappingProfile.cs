using AutoMapper;
using Products.Data.DataTransferObject;
using Products.Data.DataTransferObject.AuthenticationDto;
using Products.Data.Models;
using Products.Data.Models.IdentityModels;

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

            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
