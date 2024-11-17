using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAppRenderModes.Client;
using WebAppRenderModes.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add Http client
builder.Services.AddHttpClient();

// Add Blazor Bootstrap
builder.Services.AddBlazorBootstrap();

builder.Services.RegisterServices();

await builder.Build().RunAsync();