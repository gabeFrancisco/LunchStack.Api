using System.Security.Claims;
using AutoMapper;
using LunchStack.Api.Context;
using LunchStack.Api.Models;
using LunchStack.Api.Models.DTOs;
using LunchStack.Api.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LunchStack.Api.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpAccessor;
        public UserService(AppDbContext context, IMapper mapper, IHttpContextAccessor httpAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpAccessor = httpAccessor;
        }
        public int SelectedWorkgGroup => Int32.Parse(_httpAccessor
            .HttpContext
            .Response
            .Headers
            .FirstOrDefault(x => x.Key == "workgroup-id").Value!);

        public int UserId => int.Parse(_httpAccessor
            .HttpContext
            .User
            .Claims
            .FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier)
            .Value);

        public async Task<UserDTO> CreateAsync(UserDTO userDto)
        {
            var user = _mapper.Map<UserDTO, User>(userDto);

            if (_context.Users.Any(dbUser =>
                    dbUser.Username == user.Username
                || dbUser.Email == user.Email))
            {
                throw new InvalidOperationException("Username or email already taken! Thy another one!");
            }

            string pwdHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = pwdHash;
            user.CreatedAt = DateTime.UtcNow;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return userDto;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetActualUser()
        {
            var user = await this.GetSingleUserAsync(UserId);
            return user;
        }

        public Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetSingleUserAsync(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id);

        }

        public Task<UserDTO> UpdateAsync(UserDTO entity, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserLastWorkGroupId(int workGroupId)
        {
            throw new NotImplementedException();
        }
    }
}