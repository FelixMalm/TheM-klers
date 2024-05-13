using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

using TheMäklersAPI.Data;
using TheMäklersAPI.Data.Interfaces;
using TheMäklersAPI.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Felix
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.IgnoreNullValues = true;
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<MäklersContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MäklersContext") ?? throw new InvalidOperationException("Connection string 'MäklersContext' not found.")));
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IHousing, HousingRepository>();
builder.Services.AddScoped<IAgency, AgencyRepository>();
builder.Services.AddScoped<IBroker, BrokerRepository>();

var app = builder.Build();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope()) //Author Kim
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<MäklersContext>();

    await SeedHelper.DataHelper(dbContext);
}

app.Run();
