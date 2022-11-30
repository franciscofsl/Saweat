using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Saweat.Application.Contracts.Products;
using Saweat.Blazor.Client.Clients;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddTransient(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});
// builder.Services.AddHttpClient();
// builder.Services.AddHttpClient<IProductService, ProductClient>(client =>
// {
//     client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
// }); 

var host = builder.Build();
await host.RunAsync();
