using OSA.Backend.CharacterApi.Models;

namespace OSA.Backend.CharacterApi.Repositories
{
    public abstract class BaseMockRepository<TEntity> : IRepository<TEntity> where TEntity : IDataModel, new()
    {
        protected readonly List<TEntity> entities = new();

        public virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.FromResult(entities.AsEnumerable());
        }

        public virtual Task<TEntity> GetAsync(int id)
        {
            var entity = entities.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(entity);
        }

        public virtual Task<TEntity> AddAsync(TEntity entity)
        {
            var lastId = entities.LastOrDefault()?.Id ?? 0;
            entity.Id = lastId+1;
            entities.Add(entity);
            return Task.FromResult(entity);
        }

        public virtual Task<bool> UpdateAsync(int id, TEntity entity)
        {
            var index = entities.FindIndex(e => e.Id == id);
            if (index != -1)
            {
                entities[index] = entity;
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public virtual Task<bool> DeleteAsync(int id)
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