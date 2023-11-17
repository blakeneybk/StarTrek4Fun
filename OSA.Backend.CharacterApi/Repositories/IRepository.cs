using OSA.Backend.CharacterApi.Models;

namespace OSA.Backend.CharacterApi.Repositories
{
    public interface IRepository<TEntity> where TEntity : IDataModel, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(int id, TEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
