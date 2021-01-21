using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using BugTracker.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;

namespace BugTracker
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<IBugService, BugService>();
            builder.Services.AddAuth0Authentication(options =>
            {
                builder.Configuration.Bind("OidcConfiguration", options.ProviderOptions);
                builder.Configuration.Bind("UserOptions", options.UserOptions);
            });

            await builder.Build().RunAsync();
        }
    }
}
