using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Poudlard.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("Poudlard", c => { c.BaseAddress = new Uri("https//localhost:7050/api/"); });
builder.Services.AddHttpClient("SPW", c => { c.BaseAddress = new Uri("https//spw.be/api/"); });

await builder.Build().RunAsync();
