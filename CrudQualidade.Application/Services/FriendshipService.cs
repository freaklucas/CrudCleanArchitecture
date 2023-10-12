using CrudQualidade.Application.Interfaces;
using CrudQualidade.Domain.Entities;
using CrudQualidade.Domain.Interfaces;
using System.Collections.Generic;

namespace CrudQualidade.Application.Services
{
    public class FriendshipService : IFriendshipService
    {
        private readonly IFriendshipRepository _friendshipRepository;

        public FriendshipService(IFriendshipRepository friendshipRepository)
        {
            _friendshipRepository = friendshipRepository;
        }

        public void AddFriendship(int personId1, int personId2)
        {
            _friendshipRepository.AddFriendship(personId1, personId2);
        }

        public void RemoveFriendship(int personId1, int personId2)
        {
            _friendshipRepository.RemoveFriendship(personId1, personId2);
        }

        public IEnumerable<People> GetFriendsOfPeople(int personId)
        {
            return _friendshipRepository.GetFriendsOfPeople(personId);
        }
    }
}