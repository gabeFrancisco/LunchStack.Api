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
            if (entity is null)
            {
                throw new NullReferenceException("DTO cannot be null");
            }

            var product = _mapper.Map<ProductDTO, Product>(entity);

            product.WorkgroupId = this.WorkgroupId;
            product.CreatedAt = DateTime.UtcNow;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await this.GetSingleProductAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _context.Products
                .Where(p => p.WorkgroupId == this.WorkgroupId)
                .Include(p => p.Category)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetAsync(int id)
        {
            var product = await this.GetSingleProductAsync(id);
            return _mapper.Map<Product, ProductDTO>(product);
        }

        public async Task<Product> GetSingleProductAsync(int id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<ProductDTO> UpdateAsync(ProductDTO entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}