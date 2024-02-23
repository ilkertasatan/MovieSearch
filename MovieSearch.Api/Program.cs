using MovieSearch.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services
    .AddApiControllers()
    .AddVersioning()
    .AddSwagger();

var app = builder.Build();

app.UseSwaggerDocumentation();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();