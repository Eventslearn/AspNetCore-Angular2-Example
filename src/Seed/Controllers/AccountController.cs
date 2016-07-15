using AspNetCoreAngular2Seed.Infrastructure.Core;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Mvc;
using AspNetCoreAngular2Seed.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetCoreAngular2Seed.Controllers
{
    /// <summary>
    /// Controller handling authentication requests
    /// </summary>
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        /// <summary>
        /// Login user POST
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("authenticate")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel user)
        {
            var result = new ObjectResult(false);
            GenericResult authenticationResult = null;
            try
            {
                var claims = new List<Claim>();

                var claim = new Claim(ClaimTypes.Role, "Username", ClaimValueTypes.String, user.Username);

                await HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                    new Microsoft.AspNet.Http.Authentication.AuthenticationProperties { IsPersistent = user.RememberMe });


                authenticationResult = new GenericResult()
                {
                    Succeeded = true,
                    Message = "Authenticated"
                };

            }
            catch
            {
                authenticationResult = new GenericResult()
                {
                    Succeeded = false,
                    Message = "Failed to authenticate"
                };

            }

            result = new ObjectResult(authenticationResult);
            return result;
        }

        /// <summary>
        /// Logout POST
        /// </summary>
        /// <returns></returns>
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.Authentication.SignOutAsync("Cookies");

                return Ok();
            }
            catch 
            {
                return HttpBadRequest();
            }

        }

        /// <summary>
        /// Registration POST
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody] RegistrationViewModel user)
        {
            var result = new ObjectResult(false);
            GenericResult registrationResult = null;

            try
            {
                //validate the Model
                if (ModelState.IsValid)
                {

                    registrationResult = new GenericResult()
                    {
                        Succeeded = true,
                        Message = "Registration succeeded"
                    };

                }
                else
                {
                    registrationResult = new GenericResult()
                    {
                        Succeeded = false,
                        Message = "Invalid fields."
                    };
                }
            }
            catch 
            {
                registrationResult = new GenericResult()
                {
                    Succeeded = false,
                    Message = "Failed to register"
                };

            }

            result = new ObjectResult(registrationResult);

            return result;
        }
    }
}
