using AutoMapper;
using BrasserieManager.Services.GrossisteAPI;
using BrasserieManager.Services.GrossisteAPI.Models;
using BrasserieManager.Services.GrossisteAPI.Repository;
using BrasserieManager.Services.GrossisteAPI.SwaggerFilter;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(gen =>
{
    gen.DocumentFilter<CustomSwaggerFilter>();
    gen.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddDbContext<BrasserieManager.Services.BrasserieAPI.Models.AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IGrossisteRepository, GrossisteRepository>();
builder.Services.AddScoped<IBiereGrossisteRepository, BiereGrossisteRepository>();
builder.Services.AddScoped<BrasserieManager.Services.BrasserieAPI.Repository.IBiereRepository, BrasserieManager.Services.BrasserieAPI.Repository.BiereRepository>();

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
