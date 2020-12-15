using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using BriconApi.MVC;
using BriconApi.Repositories;

namespace BriconApi
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
            services.AddCors(options =>
            {
                //options.AddDefaultPolicy(builder => builder
                //    .AllowAnyHeader()
                //    .AllowAnyMethod()
                //    .AllowAnyOrigin()
                //);
                options.AddDefaultPolicy(build =>
                {
                    var configCorsHosts = Configuration.GetSection("Cors")
                        .GetChildren().Select(c => c.Value).ToArray();

                    build.WithOrigins(configCorsHosts)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
            services.AddControllers().AddXmlSerializerFormatters();
            services.AddResponseCompression(options=>options.EnableForHttps = true);
            services.AddTransient<SqlRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors();
            app.ConfigureErrorsHandler();

            //app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseFileServer();
            app.UseResponseCompression();


            app.UseRouting();

            app.UseAuthorization();

            //app.UseResponseCompression();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
