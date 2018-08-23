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