using LunchStack.Api.Models.DTOs;

namespace LunchStack.Api.Models.Interfaces
{
    public interface IUserService : IBaseService<UserDTO>
    {
        Task<bool> UpdateUserLastWorkGroupId(int workGroupId);
        Task<UserDTO> GetActualUser();
        Task<User> GetSingleUserAsync(int id);
        Guid SelectedWorkgGroup { get; }
        int UserId { get; }
    }
}