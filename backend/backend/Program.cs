using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

using backend.Interfaces.Services;
using backend.Interfaces.Repositories;
using backend.Middlewares;
using backend.Models;
using backend.Repositories;
using backend.Services;

var builder = WebApplication.CreateBuilder(args);

var test = builder.Configuration.GetConnectionString("ebay-backend");

// Db context
builder.Services.AddDbContext<DataContext>(
     options => options.UseNpgsql(builder.Configuration.GetConnectionString("ebay-backend"))
     );


AddServices(builder);
AddCors(builder);

var app = builder.Build();

// Auto migrate model change
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<AuthorizationMiddleware>();
app.UseMiddleware<ErrorHandlerMiddleware>();

// Serve static content from wwwroot folder on root path
app.UseDefaultFiles();
app.UseStaticFiles();

// Fallback to client routing if no match in server
app.UseRouting();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapFallbackToFile("/index.html");
});

app.Run();

static void AddServices(WebApplicationBuilder builder)
{
    // Add services to the container.
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<ISalesArticleService, SalesArticleService>();
    builder.Services.AddScoped<ISalesArticleRepository, SalesArticleRepository>();
    builder.Services.AddScoped<ILocationRepository, LocationRepository>();
    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


}

static void AddCors(WebApplicationBuilder builder)
{
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
        });
    });
}
