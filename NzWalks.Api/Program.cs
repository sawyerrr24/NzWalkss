using Microsoft.EntityFrameworkCore;
using NzWalks.Api.Data;
using NzWalks.Api.Mappings;
using NzWalks.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NZWalksDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnectionString")));


builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<IWalkRepository, WalkRepository>();
//builder.Services.AddScoped<IRegionRepository, InMemoryRegionRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));






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
