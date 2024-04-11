using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using TheM�klersAPI.Data;
using TheM�klersAPI.Data.Interfaces;
using TheM�klersAPI.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//Hej 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<M�klersContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("M�klersContext") ?? throw new InvalidOperationException("Connection string 'M�klersContext' not found.")));
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
