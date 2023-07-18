using Blazored.FluentValidation;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Blazored.LocalStorage;
using VG.CDF.Client.Application.Interfaces.Services;
using VG.CDF.Client.Client.Models;
using VG.CDF.Client.Dto.Authentication;
using VG.CDF.Client.Interfaces.Services.RestApi;

namespace VG.CDF.Client.Pages.Authentication
{
    public partial class SignIn
    {
        private bool _passwordVisibility;
        private InputType _passwordInput = InputType.Password;
        private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
        private FluentValidationValidator _fluentValidationValidator;
        private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });

        [Inject]
        protected IAuthenticateRestApiService AuthService { get; set; }
        
        [Inject]
        protected IMessagePresentService MessagePresentService { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected ILocalStorageService LocalStorageService { get; set; }

        [Inject] IStringLocalizer<SignIn> Localizer { get; set; }

        //[Inject] IAuthenticateRestApiService AuthService { get; set; }
        public UserLogin LogInData { get; set; }

        public SignIn()
        {
            LogInData = new UserLogin();
        }

        protected override async Task OnInitializedAsync()
        {
            NavigationManager.NavigateTo("/");
        }

        public async Task LogInAsync()
        {
            var userRequest = await AuthService.LogIn(
                new UserAuthenticationRequestDto() { Email = LogInData.UserEmail, Password = LogInData.Password }
                );

            if (userRequest == null)
            {
                MessagePresentService.PresentWarning("Пользователь не найден!");
                return;
            }
            
            NavigationManager.NavigateTo("/");
           
        }

        private void TogglePasswordVisibility()
        {
            if (_passwordVisibility)
            {
                _passwordVisibility = false;
                _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
                _passwordInput = InputType.Password;
            }
            else
            {
                _passwordVisibility = true;
                _passwordInputIcon = Icons.Material.Filled.Visibility;
                _passwordInput = InputType.Text;
            }
        }


    }
}
