using Microsoft.EntityFrameworkCore;
using SQLiteExammple;

MigrateDatabase();

void MigrateDatabase()
{
    var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

    var optionBuilder = new DbContextOptionsBuilder<DatabaseContext>();
    var options = optionBuilder.UseSqlite(configuration.GetConnectionString("SQLite")).Options;

    using var dbContext = new DatabaseContext(options);
    dbContext.Database.Migrate();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLite")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
