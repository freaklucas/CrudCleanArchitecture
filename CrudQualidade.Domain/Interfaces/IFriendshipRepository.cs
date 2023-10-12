using CrudQualidade.Domain.Entities;
using System.Collections.Generic;

namespace CrudQualidade.Domain.Interfaces
{
    public interface IFriendshipRepository
    {
        void AddFriendship(int personId1, int personId2);
        void RemoveFriendship(int personId1, int personId2);
        IEnumerable<People> GetFriendsOfPeople(int personId);
    }
}