using CrudQualidade.Application.Interfaces;
using CrudQualidade.Domain.Interfaces;
using CrudQualidade.Infrastructure.Data;

namespace CrudQualidade.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private PeopleRepository _peopleRepository;
        private FriendshipRepository _friendshipRepository;
        private PostRepository _postRepository;

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
        public IFriendshipRepository FriendshipRepository 
        {
            get
            {
                return _friendshipRepository ??= new FriendshipRepository(_context);
            }
        }

        public IPostRepository PostRepository
        {
            get
            {
                return _postRepository ??= new PostRepository(_context);
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
}