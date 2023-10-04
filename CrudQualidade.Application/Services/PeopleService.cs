using CrudQualidade.Application.DTOs;
using CrudQualidade.Application.Interfaces;
using CrudQualidade.Domain.Entities;

public class PeopleService : IPeopleService
{
    private readonly IUnitOfWork _unitOfWork;

    public PeopleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<People> GetAllPeoples()
    {
        return _unitOfWork.PeopleRepository.GetAllPeoples();
    }
    
    public People GetPeopleById(int id)
    {
        return _unitOfWork.PeopleRepository.GetPeopleById(id);
    }
    
    public void InsertPeople(People people)
    {
        _unitOfWork.PeopleRepository.Insert(people);
    }

    public IEnumerable<People> GetPeopleByName(string name)
    {
        return _unitOfWork.PeopleRepository.GetPeopleByName(name);
    }

    public void UpdatePeople(People people)
    {
        _unitOfWork.PeopleRepository.UpdatePeople(people);
    }

    public void DeletePeople(People people)
    {
        _unitOfWork.PeopleRepository.DeletePeople(people);
    }

    public IEnumerable<People> GetPeopleByFilters(string city, int? ageMin, int? ageMax)
    {
        return _unitOfWork.PeopleRepository.GetPeopleByFilters(city, ageMin, ageMax);
    }
}
