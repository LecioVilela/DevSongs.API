using AutoMapper;
using DevSongs.Application.Profiles;
using DevSongs.Application.Services.Implementations;
using DevSongs.Application.Services.Interfaces;
using DevSongs.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DevSongsDbContext>(o => o.UseInMemoryDatabase("DevSongs"));
builder.Services.AddAutoMapper(typeof(SongProfile));
builder.Services.AddScoped<ISongService, SongService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DevSongs.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Lécio Vilela",
            Email = "l3c1oo@gmail.com",
            Url = new Uri("https://linkedin.com/in/leciovilela")
        }
    });
    var xmlFile = "DevSongs.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
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
