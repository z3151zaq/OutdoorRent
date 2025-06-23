using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebCoreApi.Configurations;
using WebCoreApi.Data;
using WebCoreApi.Filtters;
using WebCoreApi.Middleware;
using WebCoreApi.Repository;
using WebCoreApi.Repository.Interfaces;
using WebCoreApi.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddSingleton<TokenService>();
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ApiResponseActionFilter));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter 'Bearer {your JWT token}'",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

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
            },
            Array.Empty<string>()
        }
    });
});
// repository and service layer
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<EquipmentService, EquipmentService>();

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddDbContext<MyDbContext>(options =>
{
//options.UseSqlServer(
//    builder.Configuration.GetConnectionString("MyDBConnection"));
    options.UseSqlite(configuration.GetConnectionString("sqliteConnection"));
});
// authorization
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

// 自动迁移数据库
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    db.Database.Migrate();  // 这里会自动应用数据库迁移（如果有的话）
}
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

// middlewares
app.UseHttpsRedirection();
app.UseAuthentication();  // Add authentication middleware
app.UseAuthorization();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<AnotherMiddleware>();

//app.UseApiResponseWrapper();
app.MapControllers();

app.Run();
