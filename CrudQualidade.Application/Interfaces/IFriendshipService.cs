using CrudQualidade.Domain.Entities;

namespace CrudQualidade.Application.Interfaces
{
    public interface IFriendshipService
    {
        void AddFriendship(int personId1, int personId2);
        void RemoveAllRelationFriend(int personId);
        IEnumerable<People> GetFriendsOfPeople(int personId);
    }
}

