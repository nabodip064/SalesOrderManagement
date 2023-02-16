using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Order.web;
using Order.web.Bases.Interfaces;
using Order.web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<ISalesOrderService, SalesOrderService>(client => {
    client.BaseAddress = new Uri("https://localhost:7040/");
});
builder.Services.AddHttpClient<IWindowService, WindowService>(client => {
    client.BaseAddress = new Uri("https://localhost:7040/");
});
builder.Services.AddHttpClient<ISubElementService, SubElementService>(client => {
    client.BaseAddress = new Uri("https://localhost:7040/");
});
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7040/") });


await builder.Build().RunAsync();
