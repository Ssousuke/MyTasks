namespace MyTasks.Infra.Interface
{
    public interface IBaseCrudRepository<TEntity> where TEntity : class
    {
        Task<ICollection<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<bool> Delete(Guid id);
        Task<ICollection<TEntity>> GetByForProjectId(Guid id);
    }
}
