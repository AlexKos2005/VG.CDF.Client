using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Interfaces.Services.RestApi;
using VG.CDF.Client.Application.Wrappers;

namespace VG.CDF.Client.Infrastructure.Services.RestApi;

public abstract class WebApiServiceBase<T> : IWebApiService<T> where T: EntityBaseDto
{
    private readonly string _urn;
    private readonly ICrudService<T> _crudService;
    public WebApiServiceBase(ICrudService<T> crudService, string urn)
    {
        _crudService = crudService;
        _urn = urn;
    }
    
    public async Task<IEnumerable<T>> GetList<T>(T entity)
    {
        var result = await _crudService.Get<IEnumerable<T>>(_urn,entity);

        if (result.IsError)
        {
            return Enumerable.Empty<T>();
        }

        return result.ResultContent;
    }

    public async Task<T?> Create<T>(T entity)
    {
        var result = await _crudService.Post<T>(_urn,entity);

        if (result.IsError)
        {
            return default(T);
        }

        return result.ResultContent;
    }

    public async Task<T> Update<T>(T entity)
    {
        var result = await _crudService.Update<T>(_urn,entity);

        if (result.IsError)
        {
            return default(T);
        }

        return result.ResultContent;
    }

    public async Task<bool> Delete(T entity)
    {
        var result = await _crudService.Delete(_urn,entity);

        if (result.IsError)
        {
            return false;
        }

        return true;
    }
}