using System.Security.Claims;

namespace MovieApp.MVC.Extensions;

public static class ClaimsPrincipalExtensions
{

    public static bool IsLoggedIn(this ClaimsPrincipal user)
    {
        if (user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static string GetUserId(this ClaimsPrincipal user)
    {
        return user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
    }

    public static bool IsAdmin(this ClaimsPrincipal user)
    {
        return user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value == "Admin";
    }

    public static string GetUserMail(this ClaimsPrincipal user)
    {
        return user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
    }

    public static string GetUserName(this ClaimsPrincipal user)
    {
        return user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
    }

    public static string GetToken(this ClaimsPrincipal user)
    {
        return user.Claims.FirstOrDefault(c => c.Type == "Token")?.Value;
    }
}
