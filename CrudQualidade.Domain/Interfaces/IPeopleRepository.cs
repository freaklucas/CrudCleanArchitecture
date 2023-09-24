using CrudQualidade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudQualidade.Domain.Interfaces
{
    public interface IPeopleRepository
    {
        IEnumerable<People> GetAllPeoples();
        People GetPeopleById(int id);
    }
}
