using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LunchStack.Api.Context;
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
        public Task<OrderSheetDTO> CreateAsync(OrderSheetDTO entity)
        {
            throw new NotImplementedException();
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

        public async Task<OrderSheetDTO> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderSheetDTO> UpdateAsync(OrderSheetDTO entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}