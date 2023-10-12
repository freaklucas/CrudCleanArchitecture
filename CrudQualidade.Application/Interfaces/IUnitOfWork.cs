using CrudQualidade.Domain.Interfaces;

namespace CrudQualidade.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IPeopleRepository PeopleRepository { get; }
    IFriendshipRepository FriendshipRepository { get; }
    void Commit();
}