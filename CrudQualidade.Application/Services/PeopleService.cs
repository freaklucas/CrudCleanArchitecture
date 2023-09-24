using CrudQualidade.Application.Interfaces;
using CrudQualidade.Domain.Entities;
using CrudQualidade.Domain.Interfaces;
using System.Collections.Generic;

public class PeopleService : IPeopleService
{
    private readonly IPeopleRepository _peopleRepository;

    public PeopleService(IPeopleRepository peopleRepository)
    {
        _peopleRepository = peopleRepository;
    }

    public IEnumerable<People> GetAllPeoples()
    {
        return _peopleRepository.GetAllPeoples();
    }

    public People GetPeopleById(int id)
    {
        return _peopleRepository.GetPeopleById(id);
    }
}
