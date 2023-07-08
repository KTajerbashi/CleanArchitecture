using Common.Library;
using Domain.Library.Entities;

namespace Application.Library.Service
{
    public interface IRegisterUserService
    {
        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
    }

}
