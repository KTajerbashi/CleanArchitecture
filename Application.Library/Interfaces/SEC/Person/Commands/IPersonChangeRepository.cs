using Application.Library.Interfaces.SEC.Person.DTOs;
using Common.Library;

namespace Application.Library.Interfaces.SEC.Person.Commands
{
    public interface IPersonChangeRepository
    {
        Task<ResultDTO<long>> Execute(PersonDTO model);
    }

}
