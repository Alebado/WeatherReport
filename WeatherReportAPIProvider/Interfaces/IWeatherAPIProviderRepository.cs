using WeatherReportModel;

namespace WeatherReportAPIProvider.Interface
{
    public interface IWeatherAPIProviderRepository
    {
        public Task<WeatherReport> GetWeatherForecastAsync(Coordinates coordinates);
    }
}