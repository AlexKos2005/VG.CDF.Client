﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Client.Dto.Authentication
{
    public class UserRegistrationRequestDto
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
