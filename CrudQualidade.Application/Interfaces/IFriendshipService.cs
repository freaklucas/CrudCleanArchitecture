using CrudQualidade.Domain.Entities;

namespace CrudQualidade.Application.Interfaces
{
    public interface IFriendshipService
    {
        void AddFriendship(int personId1, int personId2);
        void RemoveFriendship(int personId1, int personId2);
        IEnumerable<People> GetFriendsOfPeople(int personId);
    }
}

