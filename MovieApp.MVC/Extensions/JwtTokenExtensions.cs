using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MovieApp.MVC.Extensions
{
    public static class JwtTokenExtensions
    {
        public static bool IsLoggedIn(this HttpContext context)
        {

            return context.Request.Cookies["Token"] != null;
            

        }

        public static string GetUserId(this HttpContext context)
        {
            var claims = GetClaims(context.Request.Cookies["Token"]);


            return claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;


        }


        public static bool IsAdmin(this HttpContext context)
        {
            var claims = GetClaims(context.Request.Cookies["Token"]);

            
           return claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value == "Admin";

        }



        public static string GetUserMail(this HttpContext context)
        {
           var claims = GetClaims(context.Request.Cookies["Token"]);

          return claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

        }


        public static string GetUserName(this HttpContext context)
        {
            var claims= GetClaims(context.Request.Cookies["Token"]);
            return claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

        }

       


        public static string GetToken(this HttpContext context)
        {
            return context.Request.Cookies["Token"];
        }


        public static List<Claim> GetClaims(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            return jsonToken.Claims.ToList();
        }

    }
}
