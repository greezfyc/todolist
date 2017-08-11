using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Core;

namespace Git.Todolist.Core.Aop
{
    /// <summary>
    /// AOP日志记录者
    /// </summary>
    public class AOPLogger : Logger
    {
        public AOPLogger(IAOPLog log) : base(log)
        {

        }
        private const string currentLoggerName = "Git.Todolist.Core.Log.Aop";

        /// <summary>
        /// 记录错误
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <param name="ex"></param>
        public static void LogError(string id, string type, string method, string args, Exception ex)
        {
            IAOPLog logger = GetLogger<IAOPLog>(currentLoggerName);
            if (logger.IsErrorEnabled)
            {
                logger.Error(id, type, method, args, ex);
            }
        }

        /// <summary>
        /// 记录消息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <param name="returnType"></param>
        /// <param name="elapsedMilliseconds"></param>
        public static void LogInfo(string id, string type, string method, string args, string returnType, long elapsedMilliseconds)
        {
            IAOPLog logger = GetLogger<IAOPLog>(currentLoggerName);
            if (logger.IsInfoEnabled)
            {
                logger.Info(id, type, method, args, returnType, elapsedMilliseconds);
            }
        }
    }



    public class AOPLogImpl : LogImpl, IAOPLog
    {
        public AOPLogImpl(ILogger logger)
            : base(logger)
        {
        }



        public void Info(string id, string type, string method, string args, string returnType, long elapsedMilliseconds)
        {
            if (this.IsInfoEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(null, Logger.Repository, Logger.Name, Level.Info, string.Empty, null);
                loggingEvent.Properties["ID"] = id;
                loggingEvent.Properties["Type"] = type;
                loggingEvent.Properties["Method"] = method;
                loggingEvent.Properties["Args"] = args;
                loggingEvent.Properties["Return"] = returnType;
                loggingEvent.Properties["ElapsedMilliseconds"] = elapsedMilliseconds;
                Logger.Log(loggingEvent);
            }
        }

        public void Error(string id, string type, string method, string args, Exception ex)
        {
            if (this.IsErrorEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(null, Logger.Repository, Logger.Name, Level.Error, string.Empty, ex);
                loggingEvent.Properties["ID"] = id;
                loggingEvent.Properties["Type"] = type;
                loggingEvent.Properties["Method"] = method;
                loggingEvent.Properties["Args"] = args;
                Logger.Log(loggingEvent);
            }
        }
    }

    public interface IAOPLog : log4net.ILog
    {
        void Info(string id, string type, string method, string args, string returnType, long elapsedMilliseconds);

        void Error(string id, string type, string method, string args, Exception ex);
    }
}
