using WeatherReportDAL.Interface;
using WeatherReportModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Newtonsoft.Json;
using WeatherReportDAL.APIResponseModels;
using AutoMapper;

namespace WeatherReportDAL
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        private const string apiKey = "50198f798b1612a51c30da465d84c2de";
        public WeatherRepository(IHttpClientFactory httpClientFactory, IMapper mapper) 
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }
        public async Task<WeatherReport> GetWeatherForecastAsync(Coordinates coordinates)
        {
            //прикол IHttpClientFactory в том что ты создашь один инстанс этого класса и будешь юзать его по всему апликейшену
                        
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, string.Format($"https://api.openweathermap.org/data/2.5/weather?lat={coordinates.Latitude}&lon={coordinates.Longitude}&appid={apiKey}"))
            {
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
                var apiWeatherReportModel = JsonConvert.DeserializeObject<APIResponseWeatherReport>(responseContent);

                return _mapper.Map<WeatherReport>(apiWeatherReportModel);
            }
            return new WeatherReport();
        }
    }
}