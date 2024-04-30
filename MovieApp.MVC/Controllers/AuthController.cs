using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MovieApp.MVC.Extensions;
using MovieApp.MVC.Models;

using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Security.Claims;
using System.Text.Json;

namespace MovieApp.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;



        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Register()
        {
            TempData["ImagePath"] = GetRandomImage();

            return View("Form");
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                TempData["ImagePath"] = GetRandomImage();
                return View("Form", formData);
            }

            var client = new RestClient(_configuration["AppSettings:apiUrl"]);
            var request = new RestRequest("auth/register", Method.Post);
            request.AddJsonBody(formData);
            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var loginViewModel = new LoginViewModel
                {
                    Email = formData.Email,
                    Password = formData.Password
                };

                LoginAfterRegistration(loginViewModel);


                return RedirectToAction("Detail", "Profile");
            }
            else
            {
                ModelState.AddModelError("", response.Content);
                TempData["ImagePath"] = GetRandomImage();
                return View("Form", formData);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", formData);
            }

            var client = new RestClient(_configuration["AppSettings:apiUrl"] ?? throw new ArgumentNullException("AppSettings:apiUrl"));
            var request = new RestRequest("auth/login", Method.Post);
            request.AddJsonBody(formData);
            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var token = JsonSerializer.Deserialize<AccessToken>(response.Content);

                if (token != null)
                {
                    // JWT token'dan gelen claim'leri al
                    var claims = JwtTokenExtensions.GetClaims(token.Token);

                    claims.Add(new Claim("Token", token.Token));
       
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


                    var expireTime = token.Expiration;

                    var now= DateTime.Now;

                    var cookieExpirationTime = expireTime - now;


                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = false,
                        Expires = DateTime.UtcNow.Add(cookieExpirationTime),
                        SameSite = SameSiteMode.None
                    };


                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);





                    TempData["SuccessMessage"] = "Giriş başarılı";

                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (response.Content is null)
                {
                    ModelState.AddModelError("", "Server is not responding");
                    return View("Form", formData);
                }


                TempData["ErrorMessage"] = response.Content.ToString();
                return RedirectToAction("register","Auth");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["SuccessMessage"] = "Çıkış başarılı";
            return RedirectToAction("Index", "Home");
        }

        private string GetRandomImage()
        {
            string[] imagePaths = Directory.GetFiles(Path.Combine("wwwroot", "image", "register"), "*.png");

            for (int i = 0; i < imagePaths.Length; i++)
            {
                imagePaths[i] = Path.GetFileName(imagePaths[i]);
            }

            Random rnd = new Random();

            return imagePaths[rnd.Next(0, imagePaths.Length - 1)];
        }

        private void LoginAfterRegistration(LoginViewModel formData)
        {
            var client = new RestClient(_configuration["AppSettings:apiUrl"] ?? throw new ArgumentNullException("AppSettings:apiUrl"));
            var request = new RestRequest("auth/login", Method.Post);
            request.AddJsonBody(formData);
            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var token = JsonSerializer.Deserialize<AccessToken>(response.Content);

                if (token != null)
                {
                    // JWT token'dan gelen claim'leri al
                    var claims = JwtTokenExtensions.GetClaims(token.Token);

                    claims.Add(new Claim("Token", token.Token));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal).Wait(); // Async metodu senkron olarak çağır

                    TempData["SuccessMessage"] = "Giriş başarılı";
                }
            }
            else
            {
                if (response.Content is null)
                {
                    ModelState.AddModelError("", "Sunucu yanıt vermiyor");
                }
                else
                {
                    ModelState.AddModelError("", response.Content);
                }
            }
        }
    }
}
