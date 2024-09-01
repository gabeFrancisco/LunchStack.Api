using LunchStack.Api.Models.DTOs;

namespace LunchStack.Api.Models.Interfaces
{
    public interface IWorkgroupService : IBaseService<WorkgroupDTO>
    {
        Task<WorkgroupDTO> SelectWorkGroup(int id);
        Task<WorkgroupDTO> GetActualWorkGroup();
        string GetActualWorkGroupId();
    }
}