using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieSearch.Application.Services;
using MovieSearch.Infrastructure.OmDb;
using MovieSearch.Infrastructure.Vimeo;

namespace MovieSearch.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddServices(configuration);
    }

    private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<OmDbApiOptions>(options => configuration.GetSection("OmdbApi").Bind(options));
        services.Configure<VimeoApiOptions>(options => configuration.GetSection("VimeoApi").Bind(options));
        
        services.AddScoped<IOmDbApiService, OmDbApiService>();
        services.Decorate<IOmDbApiService, CachingOmDbApiService>();
        
        services.AddScoped<IVimeoApiService, VimeoApiService>();
        
        return services;
    }
}