using System.Reflection;
using AutoMapper;
using Lazulisoft.ApiDotNetDapper.Api.App_Start;
using Lazulisoft.ApiDotNetDapper.Api.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lazulisoft.ApiDotNetDapper.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Application
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Infrastructure
            DapperConfig.Init();
            services.AddTransient<IHeroRepository, HeroRepository>();
        }
                
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
