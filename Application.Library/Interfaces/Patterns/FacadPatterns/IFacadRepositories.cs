using Application.Library.Interfaces.Patterns.UnitOfWork;
using Application.Library.Interfaces.SEC.Person.Commands;
using Application.Library.Interfaces.SEC.Person.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.Interfaces.Patterns.FacadPatterns
{
    public interface IFacadRepositories: IUnitOfWork
    {
        #region Person
        IPersonChangeRepository PersonChangeRepository { get; }
        IPersonCreateRepository PersonCreateRepository { get; }
        IPersonDeleteRepository PersonDeleteRepository { get; }
        IPersonUpdateRepository PersonUpdateRepository { get; }

        IPersonGetAllRepository PersonGetAllRepository { get; }
        IPersonGetByGuidRepository PersonGetByGuidRepository { get; }
        IPersonGetByIDRepository PersonGetByIDRepository { get; }
        IPersonGetByNameRepository PersonGetByNameRepository { get; }
        #endregion
    }
}
