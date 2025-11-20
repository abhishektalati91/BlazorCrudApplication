using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorCrudApplication.Client;
using System.Net.Http;
using BlazorCrudApplication.Client.Interfaces;
using BlazorCrudApplication.Client.Service;
using BlazorCrudApplication.Client.Interfaces.BookDetails;
using BlazorCrudApplication.Client.Service.BookDetails;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register HttpClient with the DI container
builder.Services.AddScoped<HttpClient>(sp =>
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Optionally, register other services if needed
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<IBookDetailsService, BookDetailsService>();
await builder.Build().RunAsync();
