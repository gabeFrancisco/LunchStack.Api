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

        public Task<TableDTO> CreateAsync(TableDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TableDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TableDTO> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TableDTO> UpdateAsync(TableDTO entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}