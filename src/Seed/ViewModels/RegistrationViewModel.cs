using System.ComponentModel.DataAnnotations;

/// <summary>
/// View model to serialize new user registration request from Angular2 
/// </summary>
namespace AspNetCoreAngular2Seed.ViewModels
{
    public class RegistrationViewModel
    {
        /// <summary>
        /// User Name
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
