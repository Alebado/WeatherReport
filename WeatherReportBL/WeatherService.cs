using WeatherReportBL.Interface;
using WeatherReportDAL.Interfaces;
using WeatherReportAPIProvider.Interface;
using WeatherReportModel;

namespace WeatherReportBL
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;
        private readonly IWeatherAPIProviderRepository _weatherAPIProviderRepository;
        public WeatherService(IWeatherRepository weatherRepository, IWeatherAPIProviderRepository weatherAPIProviderRepository)
        {
            _weatherRepository = weatherRepository;
            _weatherAPIProviderRepository = weatherAPIProviderRepository;
        }
        public async Task<WeatherReport> GetWeatherForecastAsync(Coordinates coordinates)
        {
            var report = await _weatherRepository.GetByCoordinatesAsync(coordinates);
            if (report is not null) 
            {
                return report;
            }
            report = await _weatherAPIProviderRepository.GetWeatherForecastAsync(coordinates);
            report.Coordinates = coordinates; //in case API returns different coordinates
            await _weatherRepository.SaveAsync(report);
            return report;
        }
    }
}