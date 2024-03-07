namespace PintosTechnicalApp.Interfaces.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<Guid> Insert(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task<bool> Delete(Guid id);
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById(Guid id);
}
