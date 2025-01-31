using NLog;
namespace StudentPortal.web.Log
{
    public class LoggingService : ILoggingService
    {
        private static readonly NLog.ILogger logger = LogManager.GetCurrentClassLogger();

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }

        public void LogError(string message, Exception? ex = null)
        {
            if (ex != null)
            {
                logger.Error(ex, message);
            }
            else
            {
                logger.Error(message);
            }

        }

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }


    }
}
