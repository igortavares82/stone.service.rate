using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stone.Framework.Filter.Concretes;
using Stone.Rate.DependencyInjection;
using System.IO;
using Stone.Rate.WebApi.Configurations;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace Stone.Rating
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IConfigurationBuilder Builder { get; }

        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Builder = new ConfigurationBuilder()
                     .SetBasePath(Path.Combine(env.ContentRootPath, "Settings"))
                     .AddJsonFile("serviceclientsettings.json", optional: true, reloadOnChange: true)
                     .AddJsonFile("servicechargingsettings.json", optional: true, reloadOnChange: true);

            Builder.AddEnvironmentVariables();
            Configuration = Builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureOptions(Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc(options => options.Filters.Add(new ValidateModelStateAttribute()));

            DIFactory.Configure(services);

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info { Title = "Rate service API", Version = "v1" });

                string applicationPath = PlatformServices.Default.Application.ApplicationBasePath;
                string applicationName = PlatformServices.Default.Application.ApplicationName;
                string xmlDocPath = Path.Combine(applicationPath, $"{applicationName}.xml");
            });
        }

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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Charge application");
            });



        }
    }
}
