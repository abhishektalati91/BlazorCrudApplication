namespace BlazorCrudApplication.Client.Interfaces
{
    using BlazorCrudApplication.Client.Model;
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]?> GetWeatherForecastDetails();
    }
}
