using BlazorCrudApplication.Client.Interfaces;
using BlazorCrudApplication.Client.Service;
using BlazorCrudApplication.Client.Service.BookDetails;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register HttpClient with the DI container
builder.Services.AddScoped<HttpClient>(sp =>
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Optionally, register other services if needed
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<IBookDetailsService, BookDetailsService>();
await builder.Build().RunAsync();
