using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebCoreApi.Configurations;
using WebCoreApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddDbContext<MyDbContext>(options =>
{
//options.UseSqlServer(
//    builder.Configuration.GetConnectionString("MyDBConnection"));
    options.UseSqlite(builder.Configuration.GetConnectionString("sqliteConnection"));
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
