using System.ComponentModel.DataAnnotations;

/// <summary>
/// View model to serialize new user registration request from Angular2 
/// </summary>
namespace AspNetCoreAngular2Seed.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
