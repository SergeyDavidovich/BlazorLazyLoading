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
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            //Register Syncfusion license 
            // Version 20.4.0.38 = Nzg1ODE3QDMyMzAyZTM0MmUzMGoyN0JJQXc3VnArOHEzeVNtTlNVRXNMeVo4eDdZN3RMaUU4OGdtUG9BYTA9

            Syncfusion.Licensing.SyncfusionLicenseProvider
                .RegisterLicense("Nzg1ODE3QDMyMzAyZTM0MmUzMGoyN0JJQXc3VnArOHEzeVNtTlNVRXNMeVo4eDdZN3RMaUU4OGdtUG9BYTA9");


            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSyncfusionBlazor();
            await builder.Build().RunAsync();
        }
    }
}
