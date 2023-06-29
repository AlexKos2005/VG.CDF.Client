using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Client.Dto.Authentication
{
    public class AuthenticationResponseDto
    {
        public string JwtToken { get; set; }

        public string Key { get; set; }

        public bool IsAuthSuccessful { get; set; }
    }
}
