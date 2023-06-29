/*
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VG.CDF.Client.EndPoints;
using VG.CDF.Client.Extentions;
using VG.CDF.Client.Interfaces.Services.RestApi;

namespace VG.CDF.Client.Infrastructure.Services.RestApi;

    public class TagsGroupsRestApiService : ITagsGroupsRestApiService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;
        public TagsGroupsRestApiService(HttpClient httpClient, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }
        public async Task<List<TagLiveResponseDto>> GetTagsLive(TagsGroupsGettingInfoRequestDto tagsGroupsGetting)
        {
            var response = await _httpClient.PostAsJsonAsync($"{TagsGroupsEndPoints.GetTagsLive}",tagsGroupsGetting);

            var data = await response.ToResult<List<TagLiveResponseDto>>();

            return data;
        }

        public async Task<List<TagsGroupResponseDto>> GetTagsGroups(TagsGroupsGettingInfoRequestDto tagsGroupsGetting)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{TagsGroupsEndPoints.GetTagsGroups}", tagsGroupsGetting);

                var data = await response.ToResult<List<TagsGroupResponseDto>>();

                return data;
            }
            catch(Exception e)
            {
                throw;
            }
            
        }


    }
    */

