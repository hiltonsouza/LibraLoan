using FluentValidation;
using FluentValidation.AspNetCore;
using LibraLoan.Application.Commands.CreateBook;
using LibraLoan.Application.Commands.CreateUser;
using LibraLoan.Application.Commands.LoginUser;
using LibraLoan.Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LibraLoan.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediator()
                .AddValidator();

            return services;
        }

        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            return services;
        }

        private static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateBookCommandValidator>());

            return services;
        }
    }
}
