﻿using CrudQualidade.Domain.Entities;

namespace CrudQualidade.Application.Interfaces
{
    public interface IPeopleService
    {
        IEnumerable<People> GetAllPeoples();
        // TODO: Outros métodos, como GetById, Add, Update, Delete, etc.
        People GetPeopleById(int id);
    }
}
