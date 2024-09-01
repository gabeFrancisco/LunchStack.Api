namespace LunchStack.Api.Models.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity, int id);
        Task<bool> DeleteAsync(int id);
    }
}