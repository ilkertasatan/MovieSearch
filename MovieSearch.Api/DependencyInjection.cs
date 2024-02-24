using MovieSearch.Api.Extensions;

namespace MovieSearch.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services
            .AddApiControllers()
            .AddVersioning()
            .AddSwagger();

        return services;
    }
}