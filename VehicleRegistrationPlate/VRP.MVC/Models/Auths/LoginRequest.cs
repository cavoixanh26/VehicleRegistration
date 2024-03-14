using System.ComponentModel.DataAnnotations;

namespace VRP.MVC.Models.Auths
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
