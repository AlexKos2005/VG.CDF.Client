using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using BreadCommunityWeb.Blz.Application.Interfaces.Services.RestApi;
using BreadCommunityWeb.Blz.Infrastructure.Client.Services.Authentication;
using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;

namespace BreadCommunityWeb.Blz.Client.Pages.Factories
{
    public partial class Factories
    {
        [Inject] IUserDataRestApiService UserDataRestApiService { get; set; }

        [Inject] AuthenticationStateProvider AuthProvider { get; set; }

        protected List<FactoryResponseDto> UserFactories { get; set; }

        protected override async Task OnInitializedAsync()
        {
            UserFactories = new List<FactoryResponseDto>();
            var authState = await ((ClientAuthenticationStateProvider)AuthProvider).GetAuthenticationStateAsync();
            var claimsList = authState.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value;
            int.TryParse(claimsList, out int userId);
            var userRequestDto = new GetUserFactoriesRequestDto()
            {
                UserId = userId 
            };

            UserFactories = await UserDataRestApiService.GetUserFactories(userRequestDto);
            //NavigationManager.NavigateTo("/analytics/workingtime" +"/"+"4");

        }
    }
}
