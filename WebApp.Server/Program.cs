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

// Redirects HTTP requests to HTTPS, enforcing secure communication.
app.UseHttpsRedirection();

// Enables authorization middleware, allowing secure access to resources.
app.UseAuthorization();

app.MapControllers();

// Serves default files (e.g., index.html) for the web application.
app.UseDefaultFiles();
// Enables serving static files (e.g., CSS, JavaScript, images).
app.UseStaticFiles();
// Maps static assets, typically used for client-side frameworks.
app.MapStaticAssets();

// Configure the HTTP request pipeline.
// Configures the application to use OpenAPI (Swagger UI) in development environment.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Configures a fallback file for client-side routing, typically for single-page applications.
app.MapFallbackToFile("/index.html");

//app.MigrateDataBase(); // Applies database migrations or ensures the database is created.

// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     var context = services.GetRequiredService<Dsr.Architecture.Infrastructure.Persistence.SqlLite.SqlLiteDbContext>();
//     context.Database.Migrate();
// }

app.Run();
