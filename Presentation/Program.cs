using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddDbContext<PostgreDBContext>
    (
    options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("PostgreSQL") ?? Environment.GetEnvironmentVariable("CONNECTION_STRING");
        options.UseNpgsql(connectionString);
    }
    );
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();