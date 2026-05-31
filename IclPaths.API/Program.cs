using Asp.Versioning;
using IclPaths.API.Domain.Interfaces;
using IclPaths.API.Domain.Interfaces.AuthInterfaces;
using IclPaths.API.Domain.Interfaces.RegionInterfaces;
using IclPaths.API.Domain.Interfaces.WalkPathInterfaces;
using IclPaths.API.Domain.Repositories;
using IclPaths.API.Domain.Repositories.AuthRepository;
using IclPaths.API.Domain.Repositories.RegionRepository;
using IclPaths.API.Domain.Repositories.WalkPathRepository;
using IclPaths.API.Mappings;
using IclPaths.API.Middlewares;
using IclPaths.API.Persistance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/IclPaths_log.txt", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Information()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddApiVersioning(opt =>
{
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.DefaultApiVersion = new ApiVersion(1, 0);
    opt.ReportApiVersions = true;
});

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
    });
builder.Services.AddHttpContextAccessor();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "IclPaths API", Version = "1.0" });
    opt.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insert JWT token"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = JwtBearerDefaults.AuthenticationScheme
            }
        },
        new List<string>()
    }
});
})
    .AddSwaggerGenNewtonsoftSupport();

//DbContext
builder.Services.AddDbContext<IclPathsDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("IclPathsConnectionString")));
builder.Services.AddDbContext<IclPathsAuthDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("IclPathsAuthConnectionString")));

builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<IWalkPathRepository, WalkPathRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();

//AutoMapper Configuration
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<RegionMapper>();
    cfg.AddProfile<WalkPathMapper>();
    cfg.AddProfile<DifficultyMapper>();
    cfg.AddProfile<ImagesMapper>();
});


//Authentication and Authorization Configuration

builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("IclPaths")
    .AddEntityFrameworkStores<IclPathsAuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireNonAlphanumeric = true;
    opt.Password.RequiredLength = 6;
    opt.Password.RequiredUniqueChars = 1;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseMiddleware<ExceptionHandlerMiddleware>();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"
});
app.MapControllers();

app.Run();
