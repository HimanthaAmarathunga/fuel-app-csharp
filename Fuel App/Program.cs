/*
 * Fuel App
 * 
 * EAD ASSIGNMENT - 2022 
 * Group - 64
 * IT19040172 Perera T.W.I.V <it19040172@my.sliit.lk>
 * IT19035086 Amarathunga A.A.H.S.B. <it19035086@my.sliit.lk>
 */
using Fuel_App.Models;
using Fuel_App.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<FuelStationDbSettings>(
    builder.Configuration.GetSection(nameof(FuelStationDbSettings)));

builder.Services.AddSingleton<IFuelStationDbSettings>( sp =>
    sp.GetRequiredService<IOptions<FuelStationDbSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>( s =>
    new MongoClient(builder.Configuration.GetValue<string>("FuelStationDbSettings:ConnectionString")));

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IFSOwnerService, FSOwnerService>();
builder.Services.AddScoped<IFuelTypeService, FuelTypeService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
