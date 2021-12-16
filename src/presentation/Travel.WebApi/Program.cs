using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Application;
using Travel.Data;
using Travel.Shared;
using Travel.WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructureData();
builder.Services.AddInfrastructureShared(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddControllersWithViews(options => options.Filters.Add(new ApiExceptionFilter()));
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
