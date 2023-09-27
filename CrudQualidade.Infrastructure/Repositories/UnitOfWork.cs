using CrudQualidade.Application.Interfaces;
using CrudQualidade.Domain.Interfaces;
using CrudQualidade.Infrastructure.Data;

namespace CrudQualidade.Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private PeopleRepository _peopleRepository;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IPeopleRepository PeopleRepository
    {
        get
        {
            return _peopleRepository ??= new PeopleRepository(_context);
        }
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}