using BlazorCrudApplication.Client.Interfaces;
using BlazorCrudApplication.Client.Model;
using System.Net.Http.Json;
namespace BlazorCrudApplication.Client.Service
{
    internal class WeatherForecastService : IWeatherForecastService
    {
         
        private readonly HttpClient _httpClient;

        public WeatherForecastService(HttpClient _client)
        {
            _httpClient = _client;
        }
        public async Task<WeatherForecast[]?> GetWeatherForecastDetails()
            {
            return await _httpClient.GetFromJsonAsync<WeatherForecast[]>("/api/WeatherForecast");
        }
    }
}
