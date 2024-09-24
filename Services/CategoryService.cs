using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LunchStack.Api.Context;
using LunchStack.Api.Models;
using LunchStack.Api.Models.DTOs;
using LunchStack.Api.Models.Interfaces;

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
        public Task<CategoryDTO> CreateAsync(CategoryDTO entity)
        {
            if (entity is null)
            {
                throw new NullReferenceException("DTO cannot be null!");
            }

            var category = _mapper.Map<CategoryDTO, Category>(entity);
            category.WorkgroupId = this.WorkgroupId;
            category.CreatedAt = DateTime.UtcNow;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> UpdateAsync(CategoryDTO entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}