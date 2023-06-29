using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VG.CDF.Client.Dto.ApplicationDto;

namespace VG.CDF.Client.ViewModels
{
    using Blazored.SessionStorage;
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        protected ISessionStorageService SessionStorageService { get; set; }

        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService)
        {
            SessionStorageService = sessionStorageService;
            var tt = this.GetHashCode();
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var currentUser = new UserDto();
            currentUser = null;
            ClaimsIdentity identity = new ClaimsIdentity();

            if (currentUser!=null)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email,"pp@r.ru"),
                    new Claim(ClaimTypes.Name,"+7"),
                    new Claim("","+7")
                }, "apiauth_type");
            }


            else
            {
                identity = new ClaimsIdentity();
            }

            var user = new ClaimsPrincipal(identity);
         
            return await Task.FromResult(new AuthenticationState(user));
        }

        public async Task MarkUserAsAuthenticated()
        {
            //var currentUser = await _sessionStorageService.GetItemAsync<User>("currentUser");
            var currentUser = new UserDto();
            currentUser.Email = "email";
            ClaimsIdentity identity = new ClaimsIdentity();

            //if (currentUser != null)
            //{
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,currentUser.Email)
                }, "apiauth_type");
            //}
            //else
            //{
            //    identity = new ClaimsIdentity();
            //}

            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(GetAsync());
        }

        private async Task<AuthenticationState> GetAsync()
        {
            var currentUser = new UserDto();
            currentUser.Email = "email";
            ClaimsIdentity identity = new ClaimsIdentity();

            //if (currentUser != null)
            //{
            identity = new ClaimsIdentity(new[]
            {
                    new Claim(ClaimTypes.Name,currentUser.Email)
                }, "apiauth_type");
            //}
            //else
            //{
            //    identity = new ClaimsIdentity();
            //}

            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }

        public async Task MarkUserAsLogout()
        {
            await SessionStorageService.RemoveItemAsync("currentUser");
            var identity = new ClaimsIdentity();

            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
