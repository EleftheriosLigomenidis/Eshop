using API.errors;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extentions
{
    public static class ApplicationServicesExtentionServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            // add singleton //add transient
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.Configure<ApiBehaviorOptions>(options => { // we configure the service of the controllers 
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    //inside the actioncontex we get access the model state that our API is using to 
                    // populate the errors 
                    // we want to extract the errors and populate an array that we pass to apivalidationerro
                    var errors = actionContext.ModelState // this returns an Ienumerable of value pair thats why we use SelectMany
                    .Where(m => m.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToArray();

                    var errorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };

            }); // must be done after the controllers 
            return services;

        }
    }
}
