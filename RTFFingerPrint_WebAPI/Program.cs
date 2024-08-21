using Microsoft.EntityFrameworkCore;
using RTFFingerPrint_WebAPI.Data;
using RTFFingerPrint_WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("MySQLServer");
builder.Services.AddDbContext<DbContextClass>(options => {
   options.UseMySql(connString, ServerVersion.AutoDetect(connString));
});

builder.Services.AddScoped<IMesinAbsenService, MesinAbsenService>();
builder.Services.AddScoped<IAttandenceLogService, AttandencaLogService>();

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
