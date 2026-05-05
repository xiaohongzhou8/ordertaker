using Azure.Identity;
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

builder.Configuration.AddAzureKeyVault(
    new Uri("https://ordertakerkeyvault.vault.azure.net/"),
    new DefaultAzureCredential()
);

builder.Services.Configure<OrderTakerOptions>(
    builder.Configuration.GetSection(nameof(OrderTakerOptions))
);

builder.Services.AddScoped<IItemsService, ItemsService>();
builder.Services.AddScoped<IItemsRepository, ItemsRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();