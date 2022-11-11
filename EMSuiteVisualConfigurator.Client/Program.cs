using EMSuiteVisualConfigurator.Client;
using EMSuiteVisualConfigurator.Data.Repositories;
using EMSuiteVisualConfigurator.UseCases;
using EMSuiteVisualConfigurator.UseCases.PluginInterfaces;
using EMSuiteVisualConfigurator.UseCases.ToDoFeatures;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddTransient<IToDoRepository, ToDoRepository>();
builder.Services.AddTransient<IGetToDo, GetToDo>();


await builder.Build().RunAsync();
