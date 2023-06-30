using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using MudBlazor;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.Bootstrap;
using VG.CDF.Client.Application.Interfaces.Services;
using VG.CDF.Client.Client;
using VG.CDF.Client.Extensions;
using VG.CDF.Client.Infrastructure.Services.RestApi;
using VG.CDF.Client.Interfaces.Services.RestApi;
using VG.CDF.Client.Services.Authentication;
using VG.CDF.Client.Services.RestApi;
using VG.CDF.Client.Shared.Constants.Permission;

namespace VG.CDF.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder
                          .CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.RegistrateServices();
            
            await builder.Build().RunAsync();
        }
        
    }
}
