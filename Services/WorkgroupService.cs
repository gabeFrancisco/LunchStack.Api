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

        public WorkgroupService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<WorkgroupDTO> CreateAsync(WorkgroupDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
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

        public Task<WorkgroupDTO> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<WorkgroupDTO> SelectWorkGroup(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<WorkgroupDTO> UpdateAsync(WorkgroupDTO entity, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}