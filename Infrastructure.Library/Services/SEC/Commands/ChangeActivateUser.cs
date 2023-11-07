using Application.Library.ModelBase;
using Application.Library.Patterns.UnitOfWork;
using Application.Library.Repositories.SEC.UserRepositories.Commands;
using Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;
using Domain.Library.Entities.PRD;
using Domain.Library.Entities.SEC;

namespace Infrastructure.Library.Services.SEC.Commands
{
    public class ChangeActivateUser : IChangeActivateUser
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;
        public ChangeActivateUser(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
        }
        public async Task<ResultPublicDTO<bool>> Execute(Guid guid)
        {
            await Task.Delay(1000);
            _unitOfWork.Commit();
            return new ResultPublicDTO<bool>()
            {
                Count = 0,
                Message = "",
                Result = true
            };
        }
    }
    public class CreateUser : ICreateUser
    {
        public Task<ResultPublicDTO<long>> Execute(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
    public class UpdateUser : IUpdateUser
    {
        public Task<ResultPublicDTO<UserDTO>> Execute(UserDTO user, Guid guid)
        {
            throw new NotImplementedException();
        }
    }
    public class RemoveUser : IRemoveUser
    {
        public Task<ResultPublicDTO<bool>> Execute(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
