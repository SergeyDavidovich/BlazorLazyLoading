// https://docs.microsoft.com/ru-ru/aspnet/core/blazor/webassembly-lazy-load-assemblies?view=aspnetcore-6.0
// https://www.syncfusion.com/blogs/post/lazy-loading-syncfusion-blazor-assemblies-in-a-blazor-webassembly-application.aspx

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Blazor;

namespace BlazorLazyLoading
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Register Syncfusion license 
            Syncfusion.Licensing.SyncfusionLicenseProvider
                .RegisterLicense("NjQyNDMxQDMyMzAyZTMxMmUzMGNSU2dTTWsyWEhyM29MenpkUmlvR3lEaGphNFpQWmdDVFVKQm4xVzFZTkU9");


            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSyncfusionBlazor();
            await builder.Build().RunAsync();
        }
    }
}
