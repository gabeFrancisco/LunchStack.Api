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
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public CustomerService(AppDbContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }
        public Task<CustomerDTO> CreateAsync(CustomerDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDTO> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDTO> UpdateAsync(CustomerDTO entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}