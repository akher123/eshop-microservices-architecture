
using Ordering.Application.Data;

namespace Ordering.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            // Resolve all registered interceptors
            var interceptors = sp.GetServices<ISaveChangesInterceptor>();
            options.UseSqlServer(connectionString)
                   .AddInterceptors(interceptors.ToArray()); // Add all interceptors
        });
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }
}
