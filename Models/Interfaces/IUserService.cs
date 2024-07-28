using LunchStack.Api.Models.DTOs;

namespace LunchStack.Api.Models.Interfaces
{
    public interface IUserService : IBaseService<UserDTO>
    {
        Task<bool> UpdateUserLastWorkGroupId(Guid workGroupId);
        Task<User> GetActualUser();
        Task<User> GetSingleUserAsync(Guid id);
        Guid SelectedWorkgGroup { get; }
    }
}