using WeatherReportModel;

namespace WeatherReportDAL.Interface
{
    public interface IWeatherRepository
    {
        public Task<WeatherReport> GetWeatherForecastAsync(Coordinates coordinates);
    }
}