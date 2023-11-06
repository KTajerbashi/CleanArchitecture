namespace WEB_API.LoggerHandler
{
    public interface ILoggerHandler
    {
    }
    public enum LogLevelTypeEnum
    {
        OFF = 1,
        FATAL = 2,
        ERROR = 3,
        WARN = 4,
        INFO = 5,
        DEBUG = 6,
        TRACE = 7,
        ALL = 8,
    }
}
