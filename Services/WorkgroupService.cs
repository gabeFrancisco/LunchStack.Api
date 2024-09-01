using AutoMapper;
using LunchStack.Api.Context;
using LunchStack.Api.Models.DTOs;
using LunchStack.Api.Models.Interfaces;

namespace LunchStack.Api.Services
{
    public class WorkgroupService : IWorkgroupService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpAccessor;

        public WorkgroupService(AppDbContext context, IMapper mapper, IHttpContextAccessor httpAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpAccessor = httpAccessor;
        }
        public Task<WorkgroupDTO> CreateAsync(WorkgroupDTO entity)
        {
            throw new NotImplementedException();
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

        public Task<IEnumerable<WorkgroupDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
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