using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using VG.CDF.Client.Application.Interfaces.Services;
using VG.CDF.Client.Dto.Authentication;
using VG.CDF.Client.EndPoints;
using VG.CDF.Client.Extentions;
using VG.CDF.Client.Interfaces.Services.RestApi;
using VG.CDF.Client.Services.Authentication;

namespace VG.CDF.Client.Infrastructure.Services.RestApi;

    public class AuthenticateRestApiService : IAuthenticateRestApiService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly IMessagePresentService _messagePresentService;
        public AuthenticateRestApiService(HttpClient httpClient, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage, IMessagePresentService messagePresentService)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
            _messagePresentService = messagePresentService;
        }

        public async Task<AuthenticationResponseDto?> LogIn(UserAuthenticationRequestDto userRequestDto)
        {
            try
            {
                var tt = AuthenticationEndPoints.Authenticate;
                var response = await _httpClient.PostAsJsonAsync(AuthenticationEndPoints.Authenticate2, userRequestDto);
                var data = await response.ToResult<AuthenticationResponseDto>();
                await _localStorage.SetItemAsync("authToken", data.JwtToken);
                ((ClientAuthenticationStateProvider)_authStateProvider).NotifyUserAuthentication(userRequestDto.Email);

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", data.JwtToken);

                return data;
            }
            catch
            {
                _messagePresentService.PresentError("Ошибка авторизации");
                return null;
            }
           
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ClientAuthenticationStateProvider)_authStateProvider).NotifyUserLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }

