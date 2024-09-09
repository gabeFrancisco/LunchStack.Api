using AutoMapper;
using LunchStack.Api.Context;
using LunchStack.Api.Models;
using LunchStack.Api.Models.DTOs;
using LunchStack.Api.Models.Enums;
using LunchStack.Api.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LunchStack.Api.Services
{
    public class WorkgroupService : IWorkgroupService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpAccessor;
        private readonly IUserService _userService;

        public WorkgroupService(AppDbContext context,
                                IMapper mapper,
                                IHttpContextAccessor httpAccessor,
                                IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _httpAccessor = httpAccessor;
            _userService = userService;
        }
        public async Task<WorkgroupDTO> CreateAsync(WorkgroupDTO entity)
        {
            var actualUser = await _userService.GetActualUser();

            if (entity is null)
            {
                throw new NullReferenceException("Entity cannot be null!");
            }

            var workgroup = _mapper.Map<WorkgroupDTO, Workgroup>(entity);

            if (actualUser.Role == Role.Normal)
            {
                throw new UnauthorizedAccessException("You cannot add this worgroup because you're not the adminstrator!");
            }

            workgroup.User = actualUser;
            var workersIds = entity.Members;
            workersIds.Add(actualUser.Id);

            if (workersIds.Any())
            {
                foreach (var id in workersIds)
                {
                    var user = await _userService.GetSingleUserAsync(id);
                    if (user is null)
                    {
                        break;
                    }

                    var userWorkgroup = new UserWorkgroup()
                    {
                        CreatedAt = DateTime.UtcNow,
                        User = user,
                        Workgroup = workgroup
                    };
                    _context.UserWorkgroups.Add(userWorkgroup);
                }

            }
            _context.Workgroups.Add(workgroup);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WorkgroupDTO> GetActualWorkGroup()
        {
            throw new NotImplementedException();
        }

        public string GetActualWorkGroupId()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WorkgroupDTO>> GetAllAsync()
        {
            var workgroups = await this.GetAll();
            return _mapper.Map<IEnumerable<WorkgroupDTO>>(workgroups);
        }

        private async Task<IEnumerable<Workgroup?>> GetAll()
        {
            var actualUser = await _userService.GetActualUser();
            return await _context.UserWorkgroups
                .Where(uwg => uwg.UserId == actualUser.Id)
                .Include(uwg => uwg.Workgroup)
                .Select(uwg => uwg.Workgroup)
                .Distinct()
                .ToListAsync();
        }

        public Task<WorkgroupDTO> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WorkgroupDTO> SelectWorkGroup(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WorkgroupDTO> UpdateAsync(WorkgroupDTO entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}