using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.DataTransferObject.AuthenticationDto
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "User name is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
