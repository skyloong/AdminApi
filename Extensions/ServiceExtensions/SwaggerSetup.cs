using Common.Helper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Extensions.ServiceExtensions
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var basePath = AppContext.BaseDirectory;
            var ApiName = Appsettings.app(new string[] { "Startup", "ApiName" });
            var version = "V1";
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version, new OpenApiInfo
                {
                    Version = version,
                    Title = $"{ApiName} 接口文档——{RuntimeInformation.FrameworkDescription}",
                    Description = $"{ApiName} HTTP API " + version,
                    Contact = new OpenApiContact { Name = ApiName, Email = "" },
                    License = new OpenApiLicense { Name = ApiName + " 官方文档" }
                });
                c.OrderActionsBy(o => o.RelativePath);

                var xmlPath = Path.Combine(basePath, "Api.xml");
                //默认的第二个参数是false，这个是controller的注释，记得修改
                c.IncludeXmlComments(xmlPath);

                //这个就是Model层的xml文件名
                var xmlModelPath = Path.Combine(basePath, "Model.xml");
                c.IncludeXmlComments(xmlModelPath);

                // 开启加权小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                // 在header中添加token，传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
            });
        }
    }
}
