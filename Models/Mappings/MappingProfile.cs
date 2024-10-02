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
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Table, TableDTO>().ReverseMap();
            CreateMap<ProductOrder, ProductOrderDTO>().ReverseMap();
            CreateMap<OrderSheet, OrderSheetDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}