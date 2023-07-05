using Microsoft.EntityFrameworkCore;
using WeatherReportDAL.EntityModels;
using WeatherReportDAL.Interfaces;
using WeatherReportModel;

namespace WeatherReportDAL
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly WeatherReportContext _context;
        public WeatherRepository(WeatherReportContext context)
        {
            _context = context;
        }

        public async Task<WeatherReport> GetByIdAsync(int id)
        {
            return await _context.WeatherReports.Include(report => report.Cities).SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<WeatherReport> GetByCoordinatesAsync(Coordinates coordinates)
        {
            return await _context.WeatherReports.Include(report => report.Cities).SingleOrDefaultAsync(x => x.Coordinates == coordinates);
        }

        public async Task SaveAsync(WeatherReport weatherReport)
        {
            var existingCity = await _context.Cities.SingleOrDefaultAsync(x => x.Name == weatherReport.Cities.FirstOrDefault().Name);
            if (existingCity is not null)
            {
                weatherReport.Cities = new List<City>() { existingCity };
            }
            await _context.Set<WeatherReport>().AddAsync(weatherReport);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WeatherReport weatherReport)
        {
            _context.Entry(weatherReport).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var report = await _context.Set<WeatherReport>().FindAsync(id);
            _context.Set<WeatherReport>().Remove(report);
            await _context.SaveChangesAsync();
        }       
    }
}