using WeatherReportBL;
using WeatherReportBL.Interface;
using WeatherReportDAL;
using Microsoft.EntityFrameworkCore;
using WeatherReportDAL.EntityModels;
using WeatherReportDAL.Interfaces;
using WeatherReportAPIProvider.Interface;
using WeatherReportAPIProvider;
using Microsoft.Extensions.Configuration;
using WeatherReportService.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();
builder.Services.AddScoped<IWeatherAPIProviderRepository, WeatherAPIProviderRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<WeatherReportContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WeatherReportContext"));
});

builder.Services.Configure<WeatherAPIRequestOptions>(
    builder.Configuration.GetSection(
        key: nameof(WeatherAPIRequestOptions)));

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
