using Common.Library.Utilities;

namespace Common.Library
{
    public static class RequestResult<T>
    {

        public static ResultDTO<T> Ok(T data)
        {
            return new ResultDTO<T>
            {
                Success = true,
                Message = StatusCode.OK.GetEnumDescription(),
                Data = data
            };
        }
        public static ResultDTO<T> BadRequest(T data)
        {
            return new ResultDTO<T>
            {
                Success = false,
                Message = StatusCode.BadRequest.GetEnumDescription(),
                Data = data
            };
        }
        public static ResultDTO<T> NotFound(T data)
        {
            return new ResultDTO<T>
            {
                Success = false,
                Message = StatusCode.NotFound.GetEnumDescription(),
                Data = data
            };
        }
        public static ResultDTO<T> MethodNotAllowed(T data)
        {
            return new ResultDTO<T>
            {
                Success = false,
                Message = StatusCode.MethodNotAllowed.GetEnumDescription(),
                Data = data
            };
        }
        public static ResultDTO<T> InternalServerError(T data)
        {
            return new ResultDTO<T>
            {
                Success = false,
                Message = StatusCode.InternalServerError.GetEnumDescription(),
                Data = data
            };
        }
        public static ResultDTO<T> TooManyRequests(T data)
        {
            return new ResultDTO<T>
            {
                Success = false,
                Message = StatusCode.TooManyRequests.GetEnumDescription(),
                Data = data
            };
        }
    }
}
