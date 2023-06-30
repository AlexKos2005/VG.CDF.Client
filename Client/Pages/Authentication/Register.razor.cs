using Blazored.FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VG.CDF.Client.Client.Models;
using VG.CDF.Client.Dto.Authentication;
using VG.CDF.Client.Interfaces.Services.RestApi;

namespace VG.CDF.Client.Pages.Authentication
{
    public partial class Register
    {

        private bool _passwordVisibility;

        [Inject] 
        protected IRegisterRestApiService RegisterRestApiService { get; set; }

        [Inject] IStringLocalizer<Register> Localizer { get; set; }

        [Parameter]
        public string MudAlert { get; set; } = string.Empty;
        private InputType _passwordInput = InputType.Password;
        private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;

        private FluentValidationValidator _fluentValidationValidator;
        private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });
        public UserRegistration RegData { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        public Register()
        {
            //MudAlert = "dsfefgerg";
            RegData = new UserRegistration();
        }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
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

        public async Task RegistAsync()
        {
            var userRegistration = new UserRegistrationRequestDto();
            userRegistration.Email = RegData.UserEmail;
            userRegistration.Password = RegData.Password;
            await RegisterRestApiService.Register(userRegistration);
            NavigationManager.NavigateTo("/validregistration");
        }

    }
}
