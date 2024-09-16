using AutoMapper;
using LunchStack.Api.Models.DTOs;

namespace LunchStack.Api.Models.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Workgroup, WorkgroupDTO>().ReverseMap();
            CreateMap<Category, Category>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}