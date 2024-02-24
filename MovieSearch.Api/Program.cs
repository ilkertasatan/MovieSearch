using MovieSearch.Api;
using MovieSearch.Api.Extensions;
using MovieSearch.Application;
using MovieSearch.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseSwaggerDocumentation();
    
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}


