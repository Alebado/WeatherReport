using WeatherReportAPIProvider.Interface;
using WeatherReportModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Newtonsoft.Json;
using WeatherReportAPIProvider.APIResponseModels;
using AutoMapper;
using Microsoft.Extensions.Options;
using WeatherReportService.Options;

namespace WeatherReportAPIProvider
{
    public class WeatherAPIProviderRepository : IWeatherAPIProviderRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        private readonly WeatherAPIRequestOptions _options;
        public WeatherAPIProviderRepository(IHttpClientFactory httpClientFactory, IMapper mapper, IOptions<WeatherAPIRequestOptions> options) 
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
            _options = options.Value;
        }
        public async Task<WeatherReport> GetWeatherForecastAsync(Coordinates coordinates)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, string.Format($"{_options.BaseURL}lat={coordinates.Latitude}&lon={coordinates.Longitude}&appid={_options.ApiKey}"));

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