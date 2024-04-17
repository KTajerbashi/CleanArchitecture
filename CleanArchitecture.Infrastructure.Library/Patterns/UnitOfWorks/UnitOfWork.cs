using AutoMapper;
using CleanArchitecture.Application.Library.Patterns.Facad.SEC;
using CleanArchitecture.Application.Library.Patterns.UnitOfWork;

namespace CleanArchitecture.Infrastructure.Library.Patterns.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;

        public UnitOfWork(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IUserFacad UserFacad => throw new NotImplementedException();

        public void BeginTransAction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
