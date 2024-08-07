using AutoMapper;
using LunchStack.Api.Models.DTOs;

namespace LunchStack.Api.Models.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}