global using BensModManager.Api.Models;
global using Microsoft.EntityFrameworkCore;
using BensModManager.Api;
using BensModManager.Api.Data;
using BensModManager.Api.Services.ModService;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IModService, ModService>();
builder.Services.AddDbContext<DataContext>();

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    //c.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");
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
