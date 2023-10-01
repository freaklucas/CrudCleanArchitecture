using CrudQualidade.Application.DTOs;
using CrudQualidade.Domain.Entities;

namespace CrudQualidade.Application.Interfaces
{
    public interface IPeopleService
    {
        IEnumerable<People> GetAllPeoples();
        People GetPeopleById(int id);
        IEnumerable<People> GetPeopleByName(string name);
        void UpdatePeople(People people);
        void InsertPeople(People people);

        void DeletePeople(People people);
    }
}
