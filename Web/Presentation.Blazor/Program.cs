using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor;
using UCR.ECCI.IS.EvaluacionTecnica.Application;
using UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.ApiClient;
using BlazorStrap;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazorStrap();
builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddApplicationLayerServices();
builder.Services.AddInfrastructureApiClientLayerServices(builder.Configuration);


await builder.Build().RunAsync();
