using CrudQualidade.Domain.Entities;

namespace CrudQualidade.Domain.Interfaces
{
    public interface IPeopleRepository
    {
        IEnumerable<People> GetAllPeoples();
        void Insert(People people);
        People GetPeopleById(int id);

        IEnumerable<People> GetPeopleByName(string name);

        void UpdatePeople(People people);

        void DeletePeople(People people);
    }
}
