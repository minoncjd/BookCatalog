using BookCatalog.Model;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace ExcentOne.BookCatalog
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServiceCollectionExtensions(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
            services.TryAddScoped<IMapper, Mapper>();
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());



        }
    }
}
