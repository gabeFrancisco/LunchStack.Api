using LunchStack.Api.Models.DTOs;

namespace LunchStack.Api.Models.Interfaces
{
    public interface IWorkgroupService : IBaseService<WorkgroupDTO>
    {
        Task<WorkgroupDTO> SelectWorkGroup(Guid id);
        Task<WorkgroupDTO> GetActualWorkGroup();
        string GetActualWorkGroupId();
    }
}