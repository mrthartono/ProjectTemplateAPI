using Microsoft.EntityFrameworkCore;
using MrtProjectTemplate.API.Installers;
using MrtProjectTemplate.API.Middleware;
using MrtProjectTemplate.Models.Shared;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddDbContext<MrtProjectTemplate.Dapper.DataAccess.AppContext>(options =>
 options.UseSqlServer(
     builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.Register();
builder.Services.RegisterSwagger();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "New Tower v1"));
});
app.UseRouting();

app.UseAuthorization();
app.UseCors(x => x
                  .AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
