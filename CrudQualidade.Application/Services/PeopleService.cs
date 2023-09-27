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
}
