using BlazorCrudApplication.Client.Interfaces;
using BlazorCrudApplication.Client.Interfaces.BookDetails;
using BlazorCrudApplication.Client.Pages;
using BlazorCrudApplication.Components;
using BlazorCrudApplication.Services;
using BlazorCrudApplication.Services.BookDetails;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();
// Register IWeatherForecastService with its implementation
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastServices>();
builder.Services.AddScoped<IBookDetailsService, BooksDetailsServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapControllers();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorCrudApplication.Client._Imports).Assembly);

app.Run();
