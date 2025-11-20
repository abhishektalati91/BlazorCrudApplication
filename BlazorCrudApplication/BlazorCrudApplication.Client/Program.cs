using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorCrudApplication.Client;
using System.Net.Http;
using BlazorCrudApplication.Client.Interfaces;
using BlazorCrudApplication.Client.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register HttpClient with the DI container
builder.Services.AddScoped<HttpClient>(sp =>
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Optionally, register other services if needed
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

await builder.Build().RunAsync();
