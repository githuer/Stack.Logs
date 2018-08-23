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
            var currentDir = Directory.GetCurrentDirectory();
            //var log4netPath = $@"{currentDir}\Config\log4net.config";
            //configuration.Configure(log4netPath);//指定log4net配置文件

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

            //var currentDir = Directory.GetCurrentDirectory();
            //var nlogPath = $@"{currentDir}\Config\nlog.config";
            //env.ConfigureNLog(nlogPath);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}