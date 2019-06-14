using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaInfo
{
    class EventLogger : ILogger
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public void LogInfo(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("The logged message cannot be null or empty.");
            }
            logger.Log(LogLevel.Info, message);
        }
        public void LogError(Exception exception)
        {
            logger.Log(LogLevel.Error, exception.Message);
        }
    }
}
