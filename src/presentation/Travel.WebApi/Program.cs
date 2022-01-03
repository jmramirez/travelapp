using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Travel.Application;
using Travel.Data;
using Travel.Identity;
using Travel.Identity.Helpers;
using Travel.Shared;
using Travel.WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructureData();
builder.Services.AddInfrastructureShared(builder.Configuration);
builder.Services.AddInfrastructureIdentity(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddControllersWithViews(options => options.Filters.Add(new ApiExceptionFilter()));
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            }, new List<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<JwtMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
