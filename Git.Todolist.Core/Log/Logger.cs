using System;
using System.Linq;
using log4net;
using log4net.Core;

namespace Git.Todolist.Core
{
    public class Logger
    {
        private ILog logger;

        public Logger(ILog log)
        {
            this.logger = log;
        }

        public void Debug(object message)
        {
            this.logger.Debug(message);
        }

        public void Error(object message)
        {
            this.logger.Error(message);
        }

        public void Info(object message)
        {
            this.logger.Info(message);
        }

        public void Warn(object message)
        {
            this.logger.Warn(message);
        }
        private static string DefaultLoggerName;
        /// <summary>
        /// 获取日志记录者
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="currentLoggerName"></param>
        /// <returns></returns>
        protected static T GetLogger<T>(string currentLoggerName)
        {
            Type type = typeof(T);
            if (type == typeof(ILog))
            {
                log4net.ILog[] loggers = log4net.LogManager.GetCurrentLoggers();
                log4net.ILog logger = loggers.FirstOrDefault(p => p.Logger.Name == currentLoggerName);
                if (logger == null)
                {
                    currentLoggerName = DefaultLoggerName;
                }

                return (T)log4net.LogManager.GetLogger(currentLoggerName);
            }
            else
            {
                throw new Exception(type.FullName + "未继承接口log4net.ILog");
            }
        }

        /// <summary>
        /// 记录事件
        /// </summary>
        /// <param name="logEvents"></param>
        public static void LogEvent(LoggingEvent[] logEvents)
        {
            if (logEvents != null)
            {
                var repositories = LoggerManager.GetAllRepositories();
                if (repositories != null && repositories.Length > 0)
                {
                    var repository = repositories[0];
                    foreach (var logEvent in logEvents)
                    {
                        repository.Log(logEvent);
                    }
                }
            }
        }
    }
}