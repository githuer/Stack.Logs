using System;

namespace Stack.Log4net
{
    /// <summary>
    /// 日志记录者
    /// 作者：tingli
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            Log4Context.Log.Debug(message);
        }

        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Debug(string message, Exception ex)
        {
            Log4Context.Log.Debug(message, ex);
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            Log4Context.Log.Info(message);
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Info(string message, Exception ex)
        {
            Log4Context.Log.Info(message, ex);
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(string message)
        {
            Log4Context.Log.Warn(message);
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Warn(string message, Exception ex)
        {
            Log4Context.Log.Warn(message, ex);
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            Log4Context.Log.Error(message);
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Error(string message, Exception ex)
        {
            Log4Context.Log.Error(message, ex);
        }
    }
}