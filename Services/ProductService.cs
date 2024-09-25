using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LunchStack.Api.Context;
using LunchStack.Api.Models.DTOs;
using LunchStack.Api.Models.Interfaces;

namespace LunchStack.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProductService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<ProductDTO> CreateAsync(ProductDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> UpdateAsync(ProductDTO entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}