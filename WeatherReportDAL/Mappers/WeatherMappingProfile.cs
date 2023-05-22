using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WeatherReportDAL.APIResponseModels;
using WeatherReportModel;

namespace WeatherReportDAL.Mappers
{
    public class WeatherMappingProfile : Profile
    {
        public WeatherMappingProfile()
        {
            CreateMap<APIResponseWeatherReport, WeatherReport>()
                .ForMember(dest => dest.Coordinates, opt => opt.MapFrom(src => new Coordinates
                {
                    Latitude = src.coord.lat, 
                    Longitude = src.coord.lon
                }))
                .ForMember(dest => dest.WeatherData, opt => opt.MapFrom(src => new WeatherData
                {
                    Tempreture = src.main.temp,
                    FeelsLikeTempreture = src.main.feels_like,
                    Pressure = src.main.pressure,
                    Humidity = src.main.humidity,
                    MinTempreture = src.main.temp_min,
                    MaxTempreture = src.main.temp_max,
                    SeaLevelPressure = src.main.sea_level,
                    GroundLevelPressure = src.main.grnd_level
                }))
                .ForMember(dest => dest.WeatherDescription, opt => opt.MapFrom(src => new WeatherDescription
                {
                    ID = src.weather.First().id,
                    Main = src.weather.First().main,
                    Description = src.weather.First().description
                }))
                .ForMember(dest => dest.Visibility, opt => opt.MapFrom(src => src.visibility));
        }
    }
}
