using IAuthenticationService = CVGenerator.Core.Services.Interfaces.IAuthenticationService;
using CVGenerator.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CVGenerator.Web.Controllers
{
    [Route("Auth")]
    public class AccountController : Controller
    {
        private readonly CurrentUser _currentUser;
        private readonly IAuthenticationService _authenticationService;

        public AccountController(
            CurrentUser currentUser,
            IAuthenticationService authenticationService)
        {
            _currentUser = currentUser;
            _authenticationService = authenticationService;
        }

        [HttpGet("AccessDenied")]
        public IActionResult AccessDenied()
        {
            // TODO: Создание страницы, с текстом - недостаточно прав, "К сожалению у вас недостаточно прав доступа. \n Вы можите запросить их у администратора."
            // пока редирект в корень
            return Redirect("/");
        }

        [HttpGet("Login")]
        public IActionResult Login([FromQuery] string returnUrl)
        {
            var loginForm = new LoginRequest { ReturnUrl = returnUrl };
            return View("Login", loginForm);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(loginRequest);
            }

            try
            {
                //TODO: Тут try catch - сделать форму под ошибку
                var user = await _authenticationService.LoginAsync(loginRequest.Login, loginRequest.Password);

                _currentUser.SetPrincipal(new ClaimsPrincipal(new ClaimsIdentity(_authenticationService.GetType().Name)));

                _currentUser.UserId = user.Id.ToString();
                _currentUser.UserRole = user.Role.ToString();
                _currentUser.UserName = user.Name;

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, _currentUser.Principal);

                if (!string.IsNullOrEmpty(loginRequest.ReturnUrl))
                {
                    return Redirect(loginRequest.ReturnUrl);
                }

                return Redirect("/");
            }
            catch (AuthenticationException)
            {
                ModelState.AddModelError("Login", "Неверный логин или пароль");
                return View(loginRequest);
            }
            catch (ApplicationException)
            {
                ModelState.AddModelError("Login", "Ошибка при входе в систему");
                return View(loginRequest);
            }
        }

        [Authorize]
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}
