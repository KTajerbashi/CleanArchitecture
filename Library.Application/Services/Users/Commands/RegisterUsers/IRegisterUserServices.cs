using Library.Common;

namespace Library.Application
{
    public interface IRegisterUserServices
    {
        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
    }
}
