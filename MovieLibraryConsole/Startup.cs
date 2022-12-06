using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Runtime.Serialization.Json;
using MovieLibraryConsole.Services;


namespace MovieLibraryConsole
{
    internal class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            //services.AddLogging(builder =>
            //{
            //    builder.AddConsole();
            //    builder.AddFile("app.log");

            //});
            services.AddTransient<IMainService, MainService>();
            services.AddTransient<IFileService, FileService>();

            return services.BuildServiceProvider();

        }
    }
}
