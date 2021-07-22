using Microsoft.Extensions.DependencyInjection;
using SampleProject.Repository.Implimentations;
using SampleProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Repository.Configurations
{
    public static class RepositryConfigurations
    {
        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddSingleton<IPersonRepository, PersonRepository>();
        }
    }
}
