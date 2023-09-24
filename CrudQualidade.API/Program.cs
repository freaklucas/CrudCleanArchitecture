using Microsoft.EntityFrameworkCore;
using CrudQualidade.Infrastructure.Data.Configuration;
using CrudQualidade.Infrastructure.Data;
using CrudQualidade.Application.Interfaces;
using CrudQualidade.Domain.Interfaces;
using CrudQualidade.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureServices(builder.Configuration);
builder.Services.AddScoped<IPeopleService, PeopleService>();
builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

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
