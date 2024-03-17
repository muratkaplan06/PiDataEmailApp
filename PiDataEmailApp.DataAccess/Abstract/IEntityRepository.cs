using System.Linq.Expressions;

namespace PiDataEmailApp.DataAccess.Abstract;

public interface IEntityRepository<T> where T : class, new()
{
    Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null);
    T? Get(Expression<Func<T, bool>>? filter);
    T? GetById(int id);
    Task Add(T entity);
    void AddList(List<T> entityList);
    void Update(int id, T entity);
    Task Delete(int id);
    
}