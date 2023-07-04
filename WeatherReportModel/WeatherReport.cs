using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReportModel
{
    public class WeatherReport : BaseEntity
    {
        public Coordinates Coordinates { get; set; } //
        public WeatherData WeatherData { get; set; } //
        public WeatherDescription WeatherDescription { get; set; } //
        public List<City> Cities { get; set; }
        public float Visibility { get; set; }
    }
    
    public class WeatherData
    {
        /// <summary>
        /// Temperature.
        /// </summary>
        public float Tempreture { get; set; }
        /// <summary>
        /// emperature. This temperature parameter accounts for the human perception of weather.
        /// </summary>
        public float FeelsLikeTempreture { get; set; }
        /// <summary>
        /// Atmospheric pressure (on the sea level, if there is no sea_level or grnd_level data)
        /// </summary>
        public float Pressure { get; set; }
        /// <summary>
        /// Humidity %
        /// </summary>
        public float Humidity { get; set; }
        /// <summary>
        /// Minimum temperature at the moment. This is minimal currently observed temperature
        /// </summary>
        public float MinTempreture { get; set; }
        /// <summary>
        /// Maximum temperature at the moment. This is maximal currently observed temperature
        /// </summary>
        public float MaxTempreture { get; set; }
        /// <summary>
        /// Atmospheric pressure on the sea level
        /// </summary>
        public float SeaLevelPressure { get; set; }
        /// <summary>
        /// Atmospheric pressure on the ground level
        /// </summary>
        public float GroundLevelPressure { get; set; }
    }

    public class WeatherDescription
    {
        /// <summary>
        /// Weather condition id
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Group of weather parameters (Rain, Snow, Extreme etc.)
        /// </summary>
        public string Main { get; set; }
        /// <summary>
        /// Weather condition within the group. You can get the output in your language
        /// </summary>
        public string Description { get; set; }

    }
}
