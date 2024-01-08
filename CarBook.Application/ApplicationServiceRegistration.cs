﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application
{
    public static class ApplicationServiceRegistration
    {
        public static  IServiceCollection AddApplicationServices(this IServiceCollection services) { 
        
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));
            return services;
        }
    }
}
