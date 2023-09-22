using Application.Library.Interfaces.SEC.Person.DTOs;
using Common.Library;

namespace Application.Library.Interfaces.SEC.Person.Queries
{
    public interface IPersonGetAllRepository
    {
        Task<ResultDTO<IEnumerable<PersonDTO>>> Execute();
    }
}
