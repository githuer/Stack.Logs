using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Stack.Log4net;
using Stack.NLogs;
using System.IO;

namespace Stack.Log.WebAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Run();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseNLog($"{Directory.GetCurrentDirectory()}\\Config\\nlog.config")
            .UseLog4net($"{Directory.GetCurrentDirectory()}\\Config\\log4net.config")
            .Build();
    }
}