using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PiDataEmailApp.DataAccess.Abstract;

namespace PiDataEmailApp.DataAccess.Concrete.EntityFramework;

public class EfEntityRepository<T, TContext> : IEntityRepository<T>
    where T : class, new()
    where TContext : DbContext
{
    private readonly TContext _context;

    public EfEntityRepository(TContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter)
    {
        return filter == null
            ? await _context.Set<T>().ToListAsync()
            : await _context.Set<T>().Where(filter).ToListAsync();
    }

    public T? Get(Expression<Func<T, bool>>? filter = null)
    {
        return filter == null
            ? _context.Set<T>().FirstOrDefault()
            : _context.Set<T>().FirstOrDefault(filter);
    }

    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    } 

    public async Task Add(T entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        await _context.SaveChangesAsync();
    }

    public void AddList(List<T> entityList)
    {
        try
        {
            _context.AddRange(entityList);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async void Update(int id, T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null) _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}
    
