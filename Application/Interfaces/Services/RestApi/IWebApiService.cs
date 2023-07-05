using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Wrappers;

namespace VG.CDF.Client.Application.Interfaces.Services.RestApi;

public interface IWebApiService<T> where T: EntityBaseDto
{
    Task<IEnumerable<T>> GetList<Tg>(Tg entity, string? urnPostFix = null);
    
    Task<T?> Create<Tc>(Tc entity, string? urnPostFix = null);
    
    Task<T?> Update<Tu>(Tu entity, string? urnPostFix = null);
    
    Task<bool> Delete<Td>(Td entity, string? urnPostFix = null);
    
    Task<bool> DeleteByBody<Td>(Td entity, string? urnPostFix = null);
}