using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Wrappers;

namespace VG.CDF.Client.Application.Interfaces.Services.RestApi;

public interface IWebApiService<T> where T: EntityBaseDto
{
    Task<IEnumerable<T>> GetList<Tg>(Tg entity);
    
    Task<T?> Create<Tc>(Tc entity);
    
    Task<T?> Update<Tu>(Tu entity);
    
    Task<bool> Delete<Td>(Td entity);
}