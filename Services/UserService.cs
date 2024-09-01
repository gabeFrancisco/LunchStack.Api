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
        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Guid SelectedWorkgGroup => throw new NotImplementedException();

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

        public Task<User> GetActualUser()
        {
            throw new NotImplementedException();
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
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
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