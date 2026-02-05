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
    // app.UseSwagger(); // Adds the middleware to serve the generated OpenAPI document
    // app.UseSwaggerUI(options =>
    // {
    //     options.SwaggerEndpoint("/openapi/v1.json", "My API V1");
    // }); // Enables an embedded version of Swagger UI
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
