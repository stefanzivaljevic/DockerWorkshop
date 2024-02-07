using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var services = builder.Services;
services.ConfigureCors();

var connectionString = configuration.GetSection("ConnectionString").Value;
services.ConfigureRepositories(connectionString);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.Services.AutoUpdateDatabaseContextAsync();
app.AddCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
