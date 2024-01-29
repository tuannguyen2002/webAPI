using Microsoft.EntityFrameworkCore;
using webAPI.DBContext;
using webAPI.Handle;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using webAPI.Repository;
using System;
using webAPI.Data.DangNhap;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//dang ky dich vu
builder.Services.AddScoped<theloaiHandle, theloaiRepo>();
builder.Services.AddScoped<tacgiaHandle, tacgiaRepo>();
builder.Services.AddScoped<nhaxbHandle, nhaxbRepo>();
builder.Services.AddScoped<sachHandle, sachRepo>();

//dang ky dich vu mapper
builder.Services.AddAutoMapper(typeof(Program));

// Dang ky DBcontext
builder.Services.AddDbContext<giaoTiepCSDL>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(connectionString);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev",
        builder => builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Thêm các d?ch v? Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularDev");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
