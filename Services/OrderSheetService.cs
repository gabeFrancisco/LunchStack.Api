using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
    public class OrderSheetService : IOrderSheetService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public OrderSheetService(AppDbContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }
        private int WorkgroupId => _userService.SelectedWorkgGroup;

        public async Task<OrderSheetDTO> CreateAsync(OrderSheetDTO entity)
        {
            if (entity is null)
            {
                throw new NullReferenceException("DTO cannot be null!");
            }

            var orderSheet = _mapper.Map<OrderSheetDTO, OrderSheet>(entity);
            orderSheet.Table = await _context.Tables.
                FirstOrDefaultAsync(t => t.Id == entity.TableId);

            if (entity.CustomerId != null)
            {
                orderSheet.Customer = await _context.Customers
                    .FirstOrDefaultAsync(c => c.Id == entity.CustomerId) ?? null;
            }

            foreach (var order in orderSheet.ProductOrders)
            {
                order.CreatedAt = DateTime.UtcNow;
                order.WorkGroupId = this.WorkgroupId;
                order.Product = null;
            }

            orderSheet.WorkGroupId = this.WorkgroupId;
            orderSheet.CreatedAt = DateTime.UtcNow;
            orderSheet.OpenBy = _userService.GetActualUser().Result.Username;

            _context.OrderSheets.Add(orderSheet);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderSheetDTO>> GetAllAsync()
        {
            var orderSheets = await _context.OrderSheets
                .Where(os => os.WorkGroupId == this.WorkgroupId)
                .Include(os => os.Customer)
                .Include(os => os.Table)
                .Include(os => os.ProductOrders)
                    .ThenInclude(p => p.Product)
                    .ThenInclude(p => p.Category)
                .ToListAsync();

            return _mapper.Map<IEnumerable<OrderSheetDTO>>(orderSheets);
        }

        public Task<OrderSheetDTO> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderSheetDTO> UpdateAsync(OrderSheetDTO entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}