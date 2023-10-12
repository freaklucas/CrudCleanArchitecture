using CrudQualidade.Domain.Entities;
using CrudQualidade.Domain.Interfaces;
using CrudQualidade.Infrastructure.Data;
using System.Linq;
using CrudQualidade.Application.DTOs;
using CrudQualidade.Infrastructure.Repository.Generic;

namespace CrudQualidade.Infrastructure.Repository
{
    public class PeopleRepository : Repository<People>, IPeopleRepository
    {
        private readonly AppDbContext _context;
        public PeopleRepository(AppDbContext context) : base(context) {
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

        public void Insert(People people)
        {
            _context.Peoples.Add(people);
            _context.SaveChanges();
        }

        public IEnumerable<People> GetPeopleByName(string name)
        {
            var lowerCaseName = name.ToLower();
            return _context.Peoples.Where(p => p.Name.ToLower().Contains(lowerCaseName)).ToList();
        }

        public void UpdatePeople(People people)
        {
            var existsPeople = _context.Peoples.Find(people.Id);
            if (existsPeople == null)
                throw new Exception("Pessoa não encontrada!");
            
            _context.Entry(existsPeople).CurrentValues.SetValues(people);
            _context.SaveChanges();
        }

        public void DeletePeople(People people)
        {
            Remove(people);
            _context.SaveChanges();
        }

        public IEnumerable<People> GetPeopleByFilters(string city, int? ageMin, int? ageMax)
        {
            var query = _context.Peoples.AsQueryable();
            if (!string.IsNullOrEmpty(city))
                query = query.Where(p => p.City.ToLower() == city.ToLower());
            if (ageMin.HasValue)
                query = query.Where(p => p.Age >= ageMin.Value);
            if (ageMax.HasValue)
                query = query.Where(p => p.Age <= ageMax.Value);
            return query.ToList();
        }
    }
}