using OSA.Backend.StarshipApi.Models;

namespace OSA.Backend.StarshipApi.Repositories
{
    public abstract class BaseMockRepository<TEntity> : IRepository<TEntity> where TEntity : IDataModel, new()
    {
        protected readonly List<TEntity> entities = new();

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.FromResult(entities.AsEnumerable());
        }

        public Task<TEntity> GetAsync(int id)
        {
            var entity = entities.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(entity);
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            var lastId = entities.LastOrDefault()?.Id ?? 0;
            entity.Id = lastId+1;
            entities.Add(entity);
            return Task.FromResult(entity);
        }

        public Task<bool> UpdateAsync(int id, TEntity entity)
        {
            var index = entities.FindIndex(e => e.Id == id);
            if (index != -1)
            {
                entities[index] = entity;
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var entity = entities.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                entities.Remove(entity);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}