namespace Domain.Service
{
    public interface IService<T>
    {
        public T Create(T entity);
        public T? Read(int id);
        public T Update(T entity);
        public void Delete(int id);
    }
}
