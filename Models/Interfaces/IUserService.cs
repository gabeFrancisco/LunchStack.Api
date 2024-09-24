using LunchStack.Api.Models.DTOs;

namespace LunchStack.Api.Models.Interfaces
{
    public interface IUserService : IBaseService<UserDTO>
    {
        Task<bool> UpdateUserLastWorkGroupId(int workGroupId);
        Task<User> GetActualUser();
        Task<User> GetSingleUserAsync(int id);
        int SelectedWorkgGroup { get; }
        int UserId { get; }
    }
}