using AutoMapper;
using DigitalizeFabricationBussiness.DTOs;
using DigitalizeFabricationBussiness.Models;

namespace DigitalizeFabricationBussiness.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserInputDTO, User>();
            CreateMap<User, UserOutputDTO>();
            CreateMap<AddressInput, Address>();
        }
    }
}