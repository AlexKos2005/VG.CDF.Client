using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using Blazored.LocalStorage;
using Blazored.Modal;
using Blazorise;
using Blazorise.Bootstrap;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Interfaces.Services;
using VG.CDF.Client.Application.Interfaces.Services.RestApi;
using VG.CDF.Client.Infrastructure.Services.RestApi;
using VG.CDF.Client.Infrastructure.Services.RestApi.Admin;
using VG.CDF.Client.Interfaces.Services.RestApi;
using VG.CDF.Client.Services.Authentication;
using VG.CDF.Client.Shared.Constants.Permission;


namespace VG.CDF.Client.Extensions
{
    public static class ServicesRegistration
    {
        public static void RegistrateServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISignUpService, SignUpService>();
            services.AddTransient<IWebApiService<UserDto>, WebApiService<UserDto>>();
            services.AddTransient<ICrudService<UserDto>, CrudService<UserDto>>();
            
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IWebApiService<CompanyDto>, WebApiService<CompanyDto>>();
            services.AddTransient<ICrudService<CompanyDto>, CrudService<CompanyDto>>();
            //services.AddScoped<ClientAuthenticationStateProvider>();
            //services.AddScoped<AuthenticationStateProvider>(provider =>
                //provider.GetRequiredService<ClientAuthenticationStateProvider>());
            
            services.AddLocalization(options =>
                {
                    options.ResourcesPath = "Resources";
                })
                .AddAuthorizationCore(options =>
                {
                    RegisterPermissionClaims(options);
                });
            
            services.AddBlazoredLocalStorage()
                .AddMudServices(configuration =>
                {
                    configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
                    configuration.SnackbarConfiguration.HideTransitionDuration = 100;
                    configuration.SnackbarConfiguration.ShowTransitionDuration = 100;
                    configuration.SnackbarConfiguration.VisibleStateDuration = 3000;
                    configuration.SnackbarConfiguration.ShowCloseIcon = false;
                });
            services.AddScoped<IAuthenticateRestApiService, AuthenticateRestApiService>();
            services.AddScoped<IRegisterRestApiService, RegisterRestApiService>();
            
            //builder.Services.AddScoped(x => new HttpClient() { BaseAddress = new Uri("http://89.44.197.196:5000") });
            services.AddScoped(x => new HttpClient() { BaseAddress = new Uri("http://localhost:5000") });
            services.AddSingleton<IDialogService, DialogService>();
            /*builder.Services.AddScoped<IUserDataRestApiService, UserDataRestApiService>();
            builder.Services.AddScoped<ITagsGroupsRestApiService, TagsGroupsRestApiService>();*/
            services.AddBlazorise();
            services.AddBlazoredModal();
            var classProvider = new BootstrapClassProvider();
            var styleProvider =new BootstrapStyleProvider();
            services.AddSingleton<IClassProvider>(classProvider);
            services.AddSingleton<IStyleProvider>(styleProvider);
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
