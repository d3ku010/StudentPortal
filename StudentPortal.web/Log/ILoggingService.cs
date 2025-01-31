namespace StudentPortal.web.Log
{
    public interface ILoggingService
    {
        void LogInfo(string message);
        void LogError(string message, Exception? ex=null);
        void LogWarn(string message);
        void LogDebug(string message);
    }
}
