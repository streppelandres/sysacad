﻿using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services;

namespace Shared
{
    public static class SharedServiceExtensions
    {
        public static void AddSharedInfraestructure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}