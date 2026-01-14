using AutoMapper;
using IclPaths.API.Domain.Interfaces.RegionInterfaces;
using IclPaths.API.Domain.Repositories.RegionRepository;
using IclPaths.API.Mappings;
using IclPaths.API.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connection string for DbContext
builder.Services.AddDbContext<IclPathsDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("IclPathsConnectionString")));
builder.Services.AddScoped<IRegionRepository, RegionRepository>();
//AutoMapper Configuration

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<RegionMapper>();
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
