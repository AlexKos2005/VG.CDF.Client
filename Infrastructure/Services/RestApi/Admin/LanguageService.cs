﻿using System.Net.Http;
using Blazored.LocalStorage;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Interfaces.Services;
using VG.CDF.Client.Application.Interfaces.Services.RestApi;
using VG.CDF.Client.Infrastructure.Services.RestApi.Base;

namespace VG.CDF.Client.Infrastructure.Services.RestApi.Admin;

public class LanguageService : WebApiServiceBase<LanguageDto>,ILanguageService
{
    protected const string _urn = "api/admin/Language/";

    public LanguageService(ICrudService<LanguageDto> crudService) : base(crudService)
    {
        base.Urn = _urn;
    }
}