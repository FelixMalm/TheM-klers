using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using TheMäklersAPI.Data;
using TheMäklersAPI.Data.Interfaces;
using TheMäklersAPI.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//Hej 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<MäklersContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MäklersContext") ?? throw new InvalidOperationException("Connection string 'MäklersContext' not found.")));
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IHousing, HousingRepository>();




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
