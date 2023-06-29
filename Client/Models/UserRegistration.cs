using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VG.CDF.Client.Client.Models
{
    public class UserRegistration
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "Too long User Name")]
        public string UserEmail { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
