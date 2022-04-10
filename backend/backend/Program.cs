using backend.Models;
using Microsoft.EntityFrameworkCore;

using backend.Helpers;
using backend.Interfaces.Services;
using backend.Interfaces.Repositories;
using backend.Repositories;
using backend.Services;

var builder = WebApplication.CreateBuilder(args);

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

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<AuthorizationMiddleware>();

app.Run();


static void AddServices(WebApplicationBuilder builder)
{
    // Add services to the container.
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<ISalesArticleService, SalesArticleService>(); 
    builder.Services.AddScoped<ISalesArticleRepository, SalesArticleRepository>();
    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Db context
    builder.Services.AddDbContext<DataContext>(
        options => options.UseNpgsql(builder.Configuration.GetConnectionString("ebay-backend"))
        );
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
