using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RoraimaProject.Config;

namespace RoraimaProject
{
    public class Startup
    {
        public static RoraimaConfiguration Conf { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Conf = new RoraimaConfiguration(Configuration);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // add logging
            services.AddSingleton(
                new LoggerFactory().AddFile(
                    Conf.LoggerConfiguration.PathToLog,
                    Conf.LoggerConfiguration.LogLevel
                    ));
            services.AddLogging();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
