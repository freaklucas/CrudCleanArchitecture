using CrudQualidade.Domain.Entities;
using CrudQualidade.Domain.Entities;
using CrudQualidade.Infrastructure.Data;
using System.Linq;
using CrudQualidade.Domain.Interfaces;
using CrudQualidade.Infrastructure.Repository.Generic;

namespace CrudQualidade.Infrastructure.Repository
{
    public class FriendshipRepository : Repository<Friendship>, IFriendshipRepository
    {
        private readonly AppDbContext _context;

        public FriendshipRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void AddFriendship(int personId1, int personId2)
        {
            var friendship = new Friendship
            {
                PersonId1 = personId1,
                PersonId2 = personId2
            };

            _context.Add(friendship);
            _context.SaveChanges();
        }

        public void RemoveFriendship(int personId1, int personId2)
        {
            var existingFriendship = _context.Friendships
                .FirstOrDefault(f => (f.PersonId1 == personId1 && f.PersonId2 == personId2) || 
                                     (f.PersonId1 == personId2 && f.PersonId2 == personId1));

            if (existingFriendship != null)
            {
                _context.Remove(existingFriendship);
                _context.SaveChanges();
            }
        }
        
        public IEnumerable<People?> GetFriendsOfPeople(int personId)
        {
            var friends1 = _context.Friendships
                .Where(f => f.PersonId1 == personId)
                .Select(f => f.People2)
                .ToList();

            var friends2 = _context.Friendships
                .Where(f => f.PersonId2 == personId)
                .Select(f => f.People1)
                .ToList();

            return friends1.Concat(friends2);
        }
    }
}