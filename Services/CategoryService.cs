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
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private int WorkgroupId => _userService.SelectedWorkgGroup;
        public CategoryService(AppDbContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<CategoryDTO> CreateAsync(CategoryDTO entity)
        {
            if (entity is null)
            {
                throw new NullReferenceException("DTO cannot be null!");
            }

            var category = _mapper.Map<CategoryDTO, Category>(entity);
            category.WorkgroupId = this.WorkgroupId;
            category.CreatedAt = DateTime.UtcNow;

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await this.GetSingleCategoryAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var categories = await _context.Categories
                .Where(cat => cat.WorkgroupId == this.WorkgroupId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        private async Task<Category> GetSingleCategoryAsync(int id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CategoryDTO> GetAsync(int id)
        {
            var category = await this.GetSingleCategoryAsync(id);
            return _mapper.Map<Category, CategoryDTO>(category);
        }

        public Task<CategoryDTO> UpdateAsync(CategoryDTO entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}