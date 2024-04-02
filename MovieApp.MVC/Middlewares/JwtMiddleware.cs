using System.IdentityModel.Tokens.Jwt;

namespace MovieApp.MVC.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Cookies["token"];
            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                var expDate = jsonToken.ValidTo;
                if (expDate < DateTime.UtcNow)
                {
                    context.Response.Redirect("/auth/login");
                }
                else
                {
                    // Add your authorization check logic here
                    // For example, check if the user has the required role or permission
                    // If not, you can redirect to an unauthorized page or return a 403 Forbidden response
                    // You can access the user's claims from the jsonToken.Claims property
                    // Example:
                    // if (!jsonToken.Claims.Any(c => c.Type == "role" && c.Value == "admin"))
                    // {
                    //     context.Response.Redirect("/auth/unauthorized");
                    //     return;
                    // }
                }
            }
            await _next(context);
        }
    }
}
