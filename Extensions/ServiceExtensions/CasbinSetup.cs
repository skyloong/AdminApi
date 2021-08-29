using Common.Helper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Extensions.ServiceExtensions
{
    public static class CasbinSetup
    {
        public static void AddCasbinSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var connection = Appsettings.app(new string[] { "SqlServerConnection" });
            var confPath = Path.Combine(AppContext.BaseDirectory, "rbac_model.conf");
            services.AddSingleton(new CasbinHelper(connection, confPath));
        }
    }
}
