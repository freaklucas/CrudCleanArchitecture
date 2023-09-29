using CrudQualidade.Domain.Entities;

namespace CrudQualidade.Application.Interfaces
{
    public interface IPeopleService
    {
        IEnumerable<People> GetAllPeoples();
        People GetPeopleById(int id);

        void InsertPeople(People people);
    }
}
