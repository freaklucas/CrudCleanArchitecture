namespace CrudQualidade.Infrastructure.Repository.Generic;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Remove(T entity);
    void Update(T entity);
}
