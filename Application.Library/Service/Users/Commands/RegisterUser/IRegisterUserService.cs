using Common.Library;

namespace Application.Library.Service
{
    public interface IRegisterUserService
    {
        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
    }

}
