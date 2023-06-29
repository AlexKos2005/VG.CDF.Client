using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Client.Dto.Authentication;
using VG.CDF.Client.EndPoints;
using VG.CDF.Client.Interfaces.Services.RestApi;

namespace VG.CDF.Client.Infrastructure.Services.RestApi;

    public class RegisterRestApiService : IRegisterRestApiService
    {
        private readonly HttpClient _httpClient;
        public RegisterRestApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Register(UserRegistrationRequestDto userRequestDto)
        {
            var response = await _httpClient.PostAsJsonAsync(RegisterEndPoints.Rigistrate, userRequestDto);
          
        }
    }

