﻿using System.Reflection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;

namespace MovieSearch.Api.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {Title = "Movie Search Api", Version = "v1"});
            c.IncludeXmlComments(GetXmlCommentsFilePath());
        });
        return services;
    }

    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie Search Api v1"));

        return app;
    }

    private static string GetXmlCommentsFilePath()
    {
        var basePath = PlatformServices.Default.Application.ApplicationBasePath;
        var fileName = $"{typeof(Program).GetTypeInfo().Assembly.GetName().Name}.xml";
        return Path.Combine(basePath, fileName);
    }
}