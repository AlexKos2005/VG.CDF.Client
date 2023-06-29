using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Wrappers;

namespace VG.CDF.Client.Application.Interfaces.Services.RestApi;

public interface IWebApiService<T> where T: EntityBaseDto
{
    Task<IEnumerable<T>> GetList<T>(T entity);
    
    Task<T?> Create<T>(T entity);
    
    Task<T> Update<T>(T entity);
    
    Task<bool> Delete(T entity);
}