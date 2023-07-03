﻿using System.Net.Http;
using Blazored.LocalStorage;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Interfaces.Services;
using VG.CDF.Client.Application.Interfaces.Services.RestApi;
using VG.CDF.Client.Infrastructure.Services.RestApi.Base;

namespace VG.CDF.Client.Infrastructure.Services.RestApi.Admin;

public class UserService : WebApiServiceBase<UserDto>,IUserService
{
    protected const string _urn = "api/admin/User/";

    public UserService(ICrudService<UserDto> crudService) : base(crudService)
    {
        base.Urn = _urn;
    }
}