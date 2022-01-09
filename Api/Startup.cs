using Api.Filter;
using Autofac;
using Common.Helper;
using Common.TypeMapper;
using Extensions.Middlewares;
using Extensions.ServiceExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new Appsettings(Configuration));
            services.AddCasbinSetup();
            services.AddAutoMapperSetup();
            services.AddCorsSetup();
            services.AddSqlsugarSetup();
            services.AddSwaggerSetup();
            services.AddJwtAuthenticationSetup();

            services.AddControllers(o =>
            {
                o.Filters.Add(typeof(PermissionFilter));
                // 全局异常过滤
                o.Filters.Add(typeof(GlobalExceptionsFilter));
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModuleRegister());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            //此处没有自定义index.html
            app.UseSwaggerMildd(() => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("Api.index.html"));
            app.UseRouting();
            app.UseCors();
            // 先开启认证
            app.UseAuthentication();
            // 然后是授权中间件
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
