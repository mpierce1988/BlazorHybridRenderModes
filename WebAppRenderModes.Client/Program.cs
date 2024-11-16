using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAppRenderModes.Client;
using WebAppRenderModes.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.RegisterServices();

await builder.Build().RunAsync();