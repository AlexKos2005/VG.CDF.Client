using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VG.CDF.Client.Dto.ApplicationDto
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

    }
}
