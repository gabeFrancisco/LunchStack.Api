using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LunchStack.Api.Context;
using LunchStack.Api.Models;
using LunchStack.Api.Models.DTOs;
using LunchStack.Api.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LunchStack.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public ProductService(AppDbContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        private int WorkgroupId => this._userService.SelectedWorkgGroup;
        public async Task<ProductDTO> CreateAsync(ProductDTO entity)
        {
            if(entity is null){
                throw new NullReferenceException("DTO cannot be null");
            }

            var product = _mapper.Map<ProductDTO, Product>(entity);

            product.WorkgroupId = this.WorkgroupId;
            product.CreatedAt = DateTime.UtcNow;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _context.Products
                .Where(p => p.WorkgroupId == this.WorkgroupId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
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