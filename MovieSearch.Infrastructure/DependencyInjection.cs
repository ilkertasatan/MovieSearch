using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieSearch.Application.Abstractions.Caching;
using MovieSearch.Application.Services;
using MovieSearch.Infrastructure.Caching.MemoryCache;
using MovieSearch.Infrastructure.Services.OmDb;
using MovieSearch.Infrastructure.Services.Vimeo;

namespace MovieSearch.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddCaching()
            .AddServices(configuration);
    }

    private static IServiceCollection AddCaching(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddScoped<ICacheProvider, CacheProvider>();
        
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<OmDbApiOptions>(options => configuration.GetSection("OmdbApi").Bind(options));
        services.Configure<VimeoApiOptions>(options => configuration.GetSection("VimeoApi").Bind(options));
        
        services.AddScoped<IOmDbApiService, OmDbApiService>();
        services.Decorate<IOmDbApiService, CachingOmDbApiService>();
        
        services.AddScoped<IVimeoApiService, VimeoApiService>();
        services.Decorate<IVimeoApiService, CachingVimeoApiService>();
        
        return services;
    }
}