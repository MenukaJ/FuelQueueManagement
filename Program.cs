using FuelQueueManagement.models;
using FuelQueueManagement.Services;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<FuelQueueManagementDataBaseSettings>(
    builder.Configuration.GetSection(nameof(FuelQueueManagementDataBaseSettings)));

builder.Services.AddSingleton<IFuelQueueManagementDataBaseSettings>(sp =>
    sp.GetRequiredService<IOptions<FuelQueueManagementDataBaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("FuelQueueManagementDataBaseSettings:ConnectionString")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFuelStationService, FuelStationService>();
builder.Services.AddScoped<IFuelDetailsService, FuelDetailsService>();
builder.Services.AddScoped<IFuelQueueService, FuelQueueService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
