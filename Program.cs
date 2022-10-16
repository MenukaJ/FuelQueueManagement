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


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
     app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
