using CrudQualidade.Domain.Interfaces;

namespace CrudQualidade.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IPeopleRepository PeopleRepository { get; }

    void Commit();
}