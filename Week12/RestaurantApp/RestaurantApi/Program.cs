using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Services;
using RestaurantApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ItemRepository>();

// builder.Services.AddSingleton<UserRepository>();
// builder.Services.AddSingleton<List<User>>();

builder.Services.AddDbContext<RepositoryDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqliteConnectionString"),
    prj => prj.MigrationsAssembly("RestaurantApi"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Global Exception Handler
app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
