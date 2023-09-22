using Application.Library.Interfaces.SEC.Person.DTOs;
using Common.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.Interfaces.SEC.Person.Queries
{
    public interface IPersonGetByIDRepository
    {
        Task<ResultDTO<PersonDTO>> Execute(object ID);
    }
}
