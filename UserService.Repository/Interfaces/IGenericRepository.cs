namespace UserService.Repository.Interfaces;

public interface IGenericRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<T?> GetAsync(int id);

    void AddAsync(T entity);

    void Update(T entity);

    void Delete(T entity);
}