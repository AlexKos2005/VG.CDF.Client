using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using BreadCommunityWeb.Blz.WebApp.Infrastructure.Settings;
using MudBlazor;
using VG.CDF.Client.Settings;

namespace VG.CDF.Client.Shared
{
    public partial class MainLayout : IDisposable
    {
        private MudTheme _currentTheme;
        private bool _rightToLeft = false;
        private async Task RightToLeftToggle(bool value)
        {
            _currentTheme = new MudTheme() { };
            _rightToLeft = value;
            await Task.CompletedTask;
        }

        protected async Task OnInitializedAsync()
        {
            _currentTheme = BlazorHeroTheme.DefaultTheme;
            //_currentTheme = await _clientPreferenceManager.GetCurrentThemeAsync();
            //_rightToLeft = await _clientPreferenceManager.IsRTL();
            //_interceptor.RegisterEvent();
        }

        public async Task DarkMode()
        {
            //bool isDarkMode = await _clientPreferenceManager.ToggleDarkModeAsync();
            //_currentTheme = isDarkMode
            //    ? BlazorHeroTheme.DefaultTheme
            //    : BlazorHeroTheme.DarkTheme;
        }

        public void Dispose()
        {
            //_interceptor.DisposeEvent();
        }
    }
}
