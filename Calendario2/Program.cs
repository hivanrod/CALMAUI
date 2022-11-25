using Calendario2;
using Calendario2.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<PrioridadesServices>();
builder.Services.AddScoped<TemasServices>();
builder.Services.AddScoped<CitasServices>();
builder.Services.AddScoped<ContactosServices>();
builder.Services.AddScoped<TareasServices>();
builder.Services.AddScoped<RepeticionesServices>();
builder.Services.AddScoped<TipoRepeticionesServices>();
builder.Services.AddScoped<TipoObjetosServices>();


await builder.Build().RunAsync();
