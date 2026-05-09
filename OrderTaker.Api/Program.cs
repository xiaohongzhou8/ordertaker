using OrderTaker.Data;
using OrderTakerRepositories;
using OrderTakerRepositories.Interfaces;
using OrderTakerRepositories.Options;
using OrderTakerServices.Interfaces;
using OrderTakerServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.Configure<ConnectionStrings>(
    builder.Configuration.GetSection(nameof(ConnectionStrings))
);

builder.Services.AddSingleton<DbInit>();

builder.Services.AddScoped<IItemsService, ItemsService>();
builder.Services.AddScoped<IItemsRepository, ItemsRepository>();


var app = builder.Build();

var dbInit = app.Services.GetRequiredService<DbInit>();
dbInit.Init();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();