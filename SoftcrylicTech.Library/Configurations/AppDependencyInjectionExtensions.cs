using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoftcrylicTech.Library.DataContext;
using SoftcrylicTech.Library.DataFactories;
using SoftcrylicTech.Library.Repositories;
using SoftcrylicTech.Library.Repositories.Interfaces;
using SoftcrylicTech.Library.Services;
using SoftcrylicTech.Library.Services.Interfaces;

namespace SoftcrylicTech.Library.Configurations
{
    public static class AppDependencyInjectionExtensions
    {
        public static void ConfigureSoftcrylicDependencyInjection(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddDbContext<TechConfContext>(db => db.EnableSensitiveDataLogging().UseSqlServer(configuration["ConnectionStrings:TechConference"]));
            serviceDescriptors.AddTransient(typeof(DbFactory<>));
            serviceDescriptors.AddAutoMapper(typeof(AutoMapperConfiguration));

            serviceDescriptors.AddScoped<ITechConferenceService, TechConferenceService>();
            serviceDescriptors.AddScoped<ITechConferenceRepo, TechConferenceRepo>();
        }
    }
}
