using WebApp.Application;
using WebApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configures and adds application-specific services, including MediatR handlers.
builder.Services.AddApplication();
// Configures and adds infrastructure-specific services, such as repository implementations and persistence settings.
builder.Services.AddInfrastructure(builder.Configuration);

// Adds controllers to the service collection, enabling MVC/API functionality.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// Adds OpenAPI (Swagger) services for API documentation and testing.
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
