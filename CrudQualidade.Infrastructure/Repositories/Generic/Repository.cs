using CrudQualidade.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CrudQualidade.Infrastructure.Repository.Generic;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private DbSet<T> _entities;

    public Repository(AppDbContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _entities.ToList();
    }

    public T GetById(int id)
    {
        return _entities.Find(id);
    }

    public void Add(T entity)
    {
        _entities.Add(entity);
    }

    public void Remove(T entity)
    {
        _entities.Remove(entity);
    }

    public void Update(T entity)
    {
        _entities.Update(entity);
    }
}
