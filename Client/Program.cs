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
            builder.Services.AddScoped<ClientAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
            provider.GetRequiredService<ClientAuthenticationStateProvider>());
            builder.Services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            })
            .AddAuthorizationCore(options =>
            {
                   RegisterPermissionClaims(options);
            });
            builder.Services.AddBlazoredLocalStorage()
           .AddMudServices(configuration =>
           {
               configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
               configuration.SnackbarConfiguration.HideTransitionDuration = 100;
               configuration.SnackbarConfiguration.ShowTransitionDuration = 100;
               configuration.SnackbarConfiguration.VisibleStateDuration = 3000;
               configuration.SnackbarConfiguration.ShowCloseIcon = false;
           });
            builder.Services.AddScoped<IAuthenticateRestApiService, AuthenticateRestApiService>();
            builder.Services.AddScoped<IRegisterRestApiService, RegisterRestApiService>();
            //builder.Services.AddScoped(x => new HttpClient() { BaseAddress = new Uri("http://89.44.197.196:5000") });
            builder.Services.AddScoped(x => new HttpClient() { BaseAddress = new Uri("http://localhost:5000") });
            builder.Services.AddSingleton<IDialogService, DialogService>();
            builder.Services.AddScoped<IUserDataRestApiService, UserDataRestApiService>();
            builder.Services.AddScoped<ITagsGroupsRestApiService, TagsGroupsRestApiService>();
            builder.Services.AddBlazorise();
            var classProvider = new BootstrapClassProvider();
            var styleProvider =new BootstrapStyleProvider();
            builder.Services.AddSingleton<IClassProvider>(classProvider);
            builder.Services.AddSingleton<IStyleProvider>(styleProvider);
            
            await builder.Build().RunAsync();
        }

        private static void RegisterPermissionClaims(AuthorizationOptions options)
        {
            foreach (var prop in typeof(Permissions).GetNestedTypes().SelectMany(c => c.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)))
            {
                var propertyValue = prop.GetValue(null);
                if (propertyValue is not null)
                {
                    options.AddPolicy(propertyValue.ToString(), policy => policy.RequireClaim(ApplicationClaimTypes.Permission, propertyValue.ToString()));
                }
            }
        }
    }
}
