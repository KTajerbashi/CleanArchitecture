using Common.Library;
using Domain.Library.Entities;
using Application.Library.Interfaces;

namespace Application.Library.Service
{
    public interface IRegisterUserService
    {
        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
    }

}
