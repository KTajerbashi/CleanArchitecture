using Application.Library.Interfaces.SEC.Person.DTOs;
using Common.Library;

namespace Application.Library.Interfaces.SEC.Person.Queries
{
    public interface IPersonGetByNameRepository
    {
        Task<ResultDTO<PersonDTO>> Execute(object name);
    }
}
