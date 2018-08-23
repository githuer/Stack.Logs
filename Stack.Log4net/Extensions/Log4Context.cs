using log4net;
using log4net.Repository;
using System.IO;

namespace Stack.Log4net
{
    /// <summary>
    /// 
    /// </summary>
    class Log4Context
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        protected internal static ILog Log { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configPath"></param>
        public static void Configure(string configPath)
        {
            FileInfo file = new FileInfo(configPath);
            ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(repository, file);

            Log = LogManager.GetLogger(repository.Name, "SystemLogger");
            Log.Info($"初始化{configPath}完成。");
        }
    }
}