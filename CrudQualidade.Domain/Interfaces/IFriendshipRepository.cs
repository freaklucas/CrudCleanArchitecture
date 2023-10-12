using CrudQualidade.Domain.Entities;
using System.Collections.Generic;

namespace CrudQualidade.Domain.Interfaces
{
    public interface IFriendshipRepository
    {
        void AddFriendship(int personId1, int personId2);
        void RemoveAllRelationFriend(int personId1);
        IEnumerable<People> GetFriendsOfPeople(int personId);
    }
}