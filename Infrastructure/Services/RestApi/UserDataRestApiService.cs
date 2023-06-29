/*using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VG.CDF.Client.Dto;
using VG.CDF.Client.EndPoints;
using VG.CDF.Client.Extentions;
using VG.CDF.Client.Interfaces.Services.RestApi;

namespace VG.CDF.Client.Infrastructure.Services.RestApi;
    public class UserDataRestApiService : IUserDataRestApiService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;
        public UserDataRestApiService(HttpClient httpClient, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

    
        public async Task<List<FactoryResponseDto>> GetUserFactories(GetUserFactoriesRequestDto userRequestDto)
        {
            var response = await _httpClient.GetAsync($"{UserDataEndPoints.GetUserFactories}?userId={userRequestDto.UserId}");
            var data = await response.ToResult<List<FactoryResponseDto>>();

            return data;
        }

        public async Task<List<DeviceWithDescriptionsDto>> GetUserDevices(int factoryId)
        {
            var response = await _httpClient.GetAsync($"{UserDataEndPoints.GetDevicesByFactoryId}?factoryId={factoryId}");
            var data = await response.ToResult<List<DeviceWithDescriptionsDto>> ();

            return data;
        }

        public async Task<List<TagParamWithDescriptions>> GetTagParamsForDevice(int deviceId)
        {
            var response = await _httpClient.GetAsync($"{UserDataEndPoints.GetTagParamsForDevice}?deviceId={deviceId}");
            var data = await response.ToResult<List<TagParamWithDescriptions>>();

            return data;
        }

        public async Task<List<LanguageResponseDto>> GetLanguages()
        {
            var response = await _httpClient.GetAsync($"{UserDataEndPoints.GetAllLanguages}");

            return await response.ToResult<List<LanguageResponseDto>>();
        }

        public async Task<HttpResponseMessage> GetTagsReport(TagParamsReportDataInfo reportDataInfo)
        {
            var response = await _httpClient.PostAsJsonAsync($"{UserDataEndPoints.GetTagsLiveReport}", reportDataInfo);

            return response;
        }

        public async Task<HttpResponseMessage> GetAlarmEventsReport(AlarmEventsReportDataInfo reportDataInfo)
        {
            var response = await _httpClient.PostAsJsonAsync($"{UserDataEndPoints.GetAlarmEventsLiveReport}", reportDataInfo);

            return response;
        }

        public async Task<HttpResponseMessage> GetTagsExcelData(TagParamsReportDataInfo reportDataInfo)
        {
            var response = await _httpClient.PostAsJsonAsync($"{UserDataEndPoints.GetTagsLiveExcelData}", reportDataInfo);

            return response;
        }
    }*/

