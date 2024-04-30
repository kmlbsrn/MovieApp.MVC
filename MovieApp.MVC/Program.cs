using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MovieApp.MVC.MappingProfile;
using MovieApp.MVC.Middlewares;
using MovieApp.MVC.Services.Abstract;
using MovieApp.MVC.Services.Concrete;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();




builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
            CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme =
            CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{

    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Home/Error";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
    options.AddPolicy("User", policy => policy.RequireClaim(ClaimTypes.Role, "User"));
});

builder.Services.AddAutoMapper(typeof(UserMappingProfile));

builder.Services.AddScoped<ApiService, ApiRequestExecutor>();
builder.Services.AddScoped<IMovieService, MovieManager>();
builder.Services.AddScoped<IReviewService, ReviewManager>();
builder.Services.AddScoped<ICreditsService, CreditsManager>();
builder.Services.AddScoped<IUserService, UserManager>();

var app = builder.Build();

app.MapControllerRoute(
       name: "areas",
       pattern: "{area:exists}/{Controller=Home}/{Action=Index}/{id?}"
       );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.UseStaticFiles();



//app.UseMiddleware<JwtMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.UseStatusCodePagesWithRedirects("/Errors/Error{0}");

app.Run();
