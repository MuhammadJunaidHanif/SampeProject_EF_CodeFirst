using Microsoft.Extensions.DependencyInjection;
using SampleProject.Business.Interfaces;
using SampleProject.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Business.Configurations
{
    public static class ServicesConfigurations
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IPersonService, PersonService>();
        }
    }
}
