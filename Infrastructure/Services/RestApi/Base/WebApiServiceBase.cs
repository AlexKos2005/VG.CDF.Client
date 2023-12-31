﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Interfaces.Services.RestApi;
using VG.CDF.Client.Application.Wrappers;

namespace VG.CDF.Client.Infrastructure.Services.RestApi.Base;

public abstract class WebApiServiceBase<T> : IWebApiService<T> where T: EntityBaseDto
{
    protected string Urn { get; set; }
    protected ICrudService<T> _crudService;
    public WebApiServiceBase(ICrudService<T> crudService)
    {
        _crudService = crudService;
    }
    
    public virtual async Task<IEnumerable<T>> GetList<Tg>(Tg entity, string? urnPostFix = null)
    {
        var result = await _crudService.Get<IEnumerable<T>>(Urn,entity);

        if (result.IsError)
        {
            return Enumerable.Empty<T>();
        }

        return result.ResultContent;
    }

    public virtual async Task<T?> Create<Tc>(Tc entity, string? urnPostFix = null)
    {
        var result = await _crudService.Post<T>(Urn,entity);

        if (result.IsError)
        {
            return default(T);
        }

        return result.ResultContent;
    }

    public virtual async Task<T?> Update<Tu>(Tu entity, string? urnPostFix = null)
    {
        var result = await _crudService.Update<T>(Urn,entity);

        if (result.IsError)
        {
            return default(T);
        }

        return result.ResultContent;
    }

    public virtual async Task<bool> Delete<Td>(Td entity, string? urnPostFix = null)
    {
        var result = await _crudService.Delete(Urn,entity);

        if (result.IsError)
        {
            return false;
        }

        return true;
    }

    public async Task<bool> DeleteByBody<Td>(Td entity, string urnPostFix = null)
    {
        var result = await _crudService.DeleteByBody(Urn,entity);

        if (result.IsError)
        {
            return false;
        }

        return true;
    }
}