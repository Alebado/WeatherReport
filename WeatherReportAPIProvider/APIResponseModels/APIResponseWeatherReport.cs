using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReportAPIProvider.APIResponseModels
{
    internal class APIResponseWeatherReport
    {
        public APIResponseCoordinates coord { get; set; }
        public APIResponseWeatherData[] weather { get; set; }
        public string @base { get; set; }
        public APIResponseMainData main { get; set; }
        public float visibility { get; set; }
    }
    internal class APIResponseCoordinates
    {
        public float lon { get; set; }
        public float lat { get; set; }
    }
    internal class APIResponseWeatherData
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    internal class APIResponseMainData
    {
        public float temp { get; set; }
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
    }

}
