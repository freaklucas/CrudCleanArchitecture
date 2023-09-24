using CrudQualidade.Domain.Entities;
using CrudQualidade.Domain.Interfaces;
using CrudQualidade.Infrastructure.Data;
using System.Linq;

namespace CrudQualidade.Infrastructure.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly AppDbContext _context;
        public PeopleRepository(AppDbContext context) {
            _context = context;
        }

        public IEnumerable<People> GetAllPeoples()
        {
            return _context.Peoples.ToList();
        }

        public People GetPeopleById(int id)
        {
            return _context.Peoples.FirstOrDefault(p => p.Id == id);
        }

    }
}
