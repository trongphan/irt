using ESIRT.Web.Features.Site;
using ESIRT.Web.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESIRT.Web.Extensions
{
    public static class ServicesConfiguration
    {
        public static void AddCustomizeMVC(this IServiceCollection services)
        {
            services.AddMvc(opt => {
                opt.Filters.Add(typeof(ValidatorActionFilter));
            })
            .AddFeatureFolders()
            .AddFluentValidation(fv => { fv.RegisterValidatorsFromAssemblyContaining<Startup>(); });

            services.AddMediatR();
        }


        public static void AddCustomServices(this IServiceCollection services)
        {
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddTransient<IValidator< ESIRT.Core.NewSite >, NewSiteValidator>();
            //services.AddTransient<IValidator<Customer>, CustomerValidator>();      
        }
    }
}
