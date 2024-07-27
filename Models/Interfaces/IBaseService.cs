namespace LunchStack.Api.Models.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}