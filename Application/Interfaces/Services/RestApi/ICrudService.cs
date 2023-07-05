using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Client.Application.Wrappers;

namespace VG.CDF.Client.Application.Interfaces.Services.RestApi;

public interface ICrudService<T>
{
    Task<Result<T>> Get<T>(string urn, object? content);
    
    Task<Result<T>> Post<T>(string urn, object? content);
    
    Task<Result<T>> Update<T>(string urn, object? content);
    
    Task<Result> Delete(string urn, object? content);
    
    Task<Result> DeleteByBody(string urn, object? content);
    
}