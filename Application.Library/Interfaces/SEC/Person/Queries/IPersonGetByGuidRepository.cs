using Application.Library.Interfaces.SEC.Person.DTOs;
using Common.Library;

namespace Application.Library.Interfaces.SEC.Person.Queries
{
    public interface IPersonGetByGuidRepository
    {
        Task<ResultDTO<PersonDTO>> Execute(Guid guid);
    }
}
