using WeatherReportModel;

namespace WeatherReportDAL.Interfaces
{
    public interface IWeatherRepository
    {
        public Task<WeatherReport> GetByIdAsync(int id);
        public Task<WeatherReport> GetByCoordinatesAsync(Coordinates coordinates);
        public Task SaveAsync(WeatherReport weatherReport);
        public Task UpdateAsync(WeatherReport weatherReport);
        public Task DeleteAsync(int id);
    }
}