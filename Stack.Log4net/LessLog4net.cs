using log4net;
using log4net.Repository;
using System;

namespace Stack.Log4net
{
    /// <summary>
    /// 
    /// </summary>
    public class LessLog4net
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        private readonly ILog _log;

        /// <summary>
        /// 
        /// </summary>
        public LessLog4net()
        {
            ILoggerRepository repository = Log4netContext.Repository;
            _log = LogManager.GetLogger(repository.Name, typeof(T));
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message"></param>
        public void Debug(string message)
        {
            _log.Debug(message);
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public void Debug(string message, Exception ex)
        {
            _log.Debug(message, ex);
        }

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message"></param>
        public void Info(string message)
        {
            _log.Info(message);
        }

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public void Info(string message, Exception ex)
        {
            _log.Info(message, ex);
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message"></param>
        public void Warn(string message)
        {
            _log.Warn(message);
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public void Warn(string message, Exception ex)
        {
            _log.Warn(message, ex);
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message)
        {
            _log.Error(message);
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public void Error(string message, Exception ex)
        {
            _log.Error(message, ex);
        }
    }
}