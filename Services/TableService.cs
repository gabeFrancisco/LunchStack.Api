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
    public class TableService : ITableService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public TableService(AppDbContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        private int WorkgroupId => _userService.SelectedWorkgGroup;

        public async Task<TableDTO> CreateAsync(TableDTO entity)
        {
            if (entity is null)
            {
                throw new NullReferenceException("DTO cannot be null");
            }

            var table = _mapper.Map<TableDTO, Table>(entity);
            table.WorkGroupId = this.WorkgroupId;
            table.CreatedAt = DateTime.UtcNow;

            _context.Tables.Add(table);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TableDTO>> GetAllAsync()
        {
            var tables = await _context.Tables
               .Where(t => t.WorkGroupId == this.WorkgroupId)
               .ToListAsync();

            return _mapper.Map<IEnumerable<TableDTO>>(tables);
        }

        public async Task<TableDTO> GetAsync(int id)
        {
            var table = await this.GetSingleTableAsync(id);
            return _mapper.Map<Table, TableDTO>(table);
        }

        private async Task<Table> GetSingleTableAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Tables
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public Task<TableDTO> UpdateAsync(TableDTO entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}