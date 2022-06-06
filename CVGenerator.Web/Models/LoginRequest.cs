using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Web.Models
{
    public class LoginRequest
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}

