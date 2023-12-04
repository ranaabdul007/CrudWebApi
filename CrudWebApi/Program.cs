using CrudWebApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ItemContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("ConEmp")
    ));

builder.Services.AddCors(options =>
{
    //options.AddPolicy("CorsPolicy",
    //    builder => builder.AllowAnyOrigin()
    //                      .AllowAnyMethod()
    //                      .AllowAnyHeader()
    //                      .AllowCredentials());
    options.AddPolicy("CorsPolicy",
    builder => builder.WithOrigins("http://localhost:3001") // Replace with your React app's origin
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();
