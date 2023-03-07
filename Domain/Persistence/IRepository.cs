namespace Domain.Persistence
{
    public interface IRepository<T>
    {
        T? GetById(int id);
        T? Save(T entity);
        T? Update(T entity);
        T? Delete(int id);
    }
}
