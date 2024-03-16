using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared
{
    public static class ApplicationServiceRegistration
    {
        public static void ConfigureApplicationService(this IServiceCollection services)
        {
            //Configure AutoMapper & MediatR
            services.AddAutoMapper(typeof(ItemMappingProfile));
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
