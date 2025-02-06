using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EventEase;
using EventEase.Services;
using Microsoft.Extensions.Caching.Memory;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSingleton<EventService>();
builder.Services.AddSingleton<UserSessionService>();
builder.Services.AddSingleton<AttendanceService>();
builder.Services.AddMemoryCache();
builder.Logging.SetMinimumLevel(LogLevel.Information);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
