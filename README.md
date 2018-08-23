# Stack.Logs
&nbsp;&nbsp;&nbsp;&nbsp;该项目是基于对log4net和nlog的进一步扩展，其中项目：Stack.Log4net是对log4net的扩展实现，而项目：Stack.NLogs则当然是对nlog的扩展啦，至于项目：Stack.Log.WebAPI那是项目的使用示例，废话不多说下面直接贴出使用方法：  
**注意：** 本文就简单以log4net为示例，NLog的扩展思路和log4net一样，只是命名空间和个别方法不同而已：

## 加载配置文件
##### 1. 在项目：**Stack.Log.WebAPI** 的Config目录下新建 **log4net.config** 文件并将其属性"复制到输出目录"设置为始终复制，家下来就就是添加配置代码啦
(示例代码如下：更多的配置，请自行参照log4net的配置说明)
``` xml
<?xml version="1.0"?>
<configuration>
  <configSections>
    <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler,  log4net"/>
  </configSections>
  <log4net>
    <root>
      <level value='ALL' />
      <appender-ref ref='FileAppender' />
    </root>
    <appender name="FileAppender" type="log4net.Appender.RollingFileAppender">
      <file type="log4net.Util.PatternString" value="Log\Log.log" />
      <appendToFile value="true" />
      <rollingStyle value="Date" />
      <datePattern value="yyyyMMdd'.log'" />
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="[%level] %date %logger %message%newline" />
      </layout>
    </appender>
  </log4net>
</configuration>
```
##### 2. 将步骤1的log4net.config进行配置文件初始化（针对初始化配置也分别扩展了两种方式1.通过Program进行初始化；2.通过Startup的Startup方法进行初始化，两种方式的代码分别如下：）
###### 2.1 通过Program来初始化配置(推荐使用)
``` C#
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
            .UseNLog($"{Directory.GetCurrentDirectory()}\\Config\\nlog.config")//NLog配置初始化
            .UseLog4net($"{Directory.GetCurrentDirectory()}\\Config\\log4net.config")//Log4net配置初始化
            .Build();
    }
}
````
###### 2.2 通过Startup的Startup方法进行初始化
``` C#
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Stack.Log.WebAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var currentDir = Directory.GetCurrentDirectory();//程序根目录

            //命名空间：Stack.Log4net
            //var log4netPath = $@"{currentDir}\Config\log4net.config";
            //configuration.Configure(log4netPath);

            //命名空间：Stack.NLogs
            //var nlogPath = $@"{currentDir}\Config\nlog.config";
            //configuration.Configure(nlogPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
```

##### 2.3 好啦配置已经初始化结束，下面我们就可以
``` C#
using Microsoft.AspNetCore.Mvc;
using System;

namespace Stack.Log.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/values")]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly NLog.Logger _log = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                Log4net.Logger.Debug($"Log4net调试日志：{Guid.NewGuid().ToString("N")}");
                Log4net.Logger.Info($"Log4net消息日志：{Guid.NewGuid().ToString("N")}");
                Log4net.Logger.Warn($"Log4net警告日志：{Guid.NewGuid().ToString("N")}");

                NLogs.NLogger.Debug($"NLog调试日志：{Guid.NewGuid().ToString("N")}");
                NLogs.NLogger.Info($"NLog消息日志：{Guid.NewGuid().ToString("N")}");
                NLogs.NLogger.Warn($"NLog警告日志：{Guid.NewGuid().ToString("N")}");
                throw new NullReferenceException("空异常");
            }
            catch (Exception ex)
            {
                Log4net.Logger.Error($"Log4net异常日志：{Guid.NewGuid().ToString("N")}", ex);
                NLogs.NLogger.Error($"NLog异常日志：{Guid.NewGuid().ToString("N")}", ex);
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}
```

##### 2.4 关于控制台使用说明
如果是控制台直接调用 Log4Extensions 下面的 Configure方法即可，扩展方法的代码如下：
``` C#
/// <summary>
/// 设置配置文件
/// 注意：该方法默认调用当前项目执行目录下面的log4net.config作为配置文件
/// </summary>
/// <param name="configuration"></param>
/// <returns></returns>
public static void Configure()
{
    var currentDir = Directory.GetCurrentDirectory();
    var configPath = $@"{currentDir}\nlog.config";
    Configure(configPath);
}

/// <summary>
/// 设置配置文件
/// </summary>
/// <param name="configuration"></param>
/// <param name="configPath">配置文件路径</param>
/// <returns></returns>
public static void Configure(string configPath)
{
    Log4Context.Configure(configPath);
}
```

