using System.Threading.Tasks;
using VG.CDF.Client.Dto.Authentication;

namespace VG.CDF.Client.Interfaces.Services.RestApi
{
    public interface IRegisterRestApiService
    {
        Task Register(UserRegistrationRequestDto userRequestDto);
    }
}
