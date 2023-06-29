using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Client.Dto.Authentication;

namespace VG.CDF.Client.Interfaces.Services.RestApi
{
    public interface IAuthenticateRestApiService
    {
        Task<AuthenticationResponseDto?> LogIn(UserAuthenticationRequestDto userRequestDto);

        Task Logout();
    }
}
