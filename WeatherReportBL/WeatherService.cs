using WeatherReportBL.Interface;
using WeatherReportDAL.Interface;
using WeatherReportModel;

namespace WeatherReportBL
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;
        public WeatherService(IWeatherRepository weatherRepository) 
        {
            _weatherRepository = weatherRepository;
        }
        public Task<WeatherReport> GetWeatherForecastAsync(Coordinates coordinates)
        {
            return _weatherRepository.GetWeatherForecastAsync(coordinates);
        }
    }
}