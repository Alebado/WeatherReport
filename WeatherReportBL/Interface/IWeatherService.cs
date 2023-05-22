using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherReportModel;

namespace WeatherReportBL.Interface
{
    public interface IWeatherService
    {
        public Task<WeatherReport> GetWeatherForecastAsync(Coordinates coordinates);
    }
}
