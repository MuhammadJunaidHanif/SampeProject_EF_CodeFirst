using EF_CodefFirst_SampleProject.Mvc;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SampleProject.Business.Configurations;
using SampleProject.Repository.Configurations;
using SampleProjectDatabase.DatabaseContext;
using SampleProjectModels.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_CodefFirst_SampleProject
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EF_CodefFirst_SampleProject", Version = "v1" });
            });

            var connectionString = Configuration.GetValue<string>("ConnectionStrings:Default");
            ServicesConfigurations.RegisterServices(services);
            RepositryConfigurations.RegisterRepository(services);
            services.AddMvc();
            services.AddDbContext<CompanyManagementDbContext>(
                item => 
                item.UseSqlServer(connectionString),ServiceLifetime.Singleton);
            services.AddMvc(options =>
            options.Filters.Add<HttpGlobalExceptionFilter>())
                .AddFluentValidation(fv => 
                fv.RegisterValidatorsFromAssemblyContaining<SignupValidator>());
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EF_CodefFirst_SampleProject v1"));
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

