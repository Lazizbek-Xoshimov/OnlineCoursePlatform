using ContentServiceWebApi.Data;
using ContentServiceWebApi.Features.Contents.Mappers;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuring with MongoDb
builder.Services.Configure<ContentDatabaseSettings>(
    builder.Configuration.GetSection("ContentDatabaseSettings"));

// Creating a MongoClient instance
builder.Services.AddSingleton<IMongoClient>(_ =>
{
    var connectionString = builder.Configuration.GetSection("ContentDatabaseSettings:ConnectionString").Value;

    return new MongoClient(connectionString);
});
builder.Services.AddSingleton<IMongoClient>(_ =>
{
    var settings = new MongoClientSettings()
    {
        Scheme = ConnectionStringScheme.MongoDB,
        Server = new MongoServerAddress("localhost", 27017)
    };

    return new MongoClient(settings);
});

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
