using MovieApp.MVC.Extensions;
using MovieApp.MVC.Services.Abstract;

using RestSharp;
using System.Net;
using System.Text.Json;

namespace MovieApp.MVC.Services.Concrete;

public class ApiRequestExecutor : ApiService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApiRequestExecutor(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
    }

    public Task<RestResponse> ExecuteMovieApiRequestAsync(string resource, Method method)
    {
        

        var options = new RestClientOptions
        {
            BaseUrl = new Uri(_configuration["AppSettings:apiUrl"]),
            
        };

        var client = new RestClient(options);

        var request = new RestRequest(resource, method);

        request.AddHeader("Authorization",$"Bearer {ClaimsPrincipalExtensions.GetToken(_httpContextAccessor.HttpContext.User)}");
       
        return client.ExecuteAsync(request);

    }

    public Task<RestResponse> ExecuteMovieApiRequestAsync(string resource, Method method, object body)
    {
     
    
        var options = new RestClientOptions
        {
            BaseUrl = new Uri(_configuration["AppSettings:apiUrl"]),
            
        };

        Console.WriteLine(ClaimsPrincipalExtensions.GetToken(_httpContextAccessor.HttpContext.User));

        var client = new RestClient(options);

        var request = new RestRequest(resource, method);

        request.AddHeader("Authorization",$"Bearer {ClaimsPrincipalExtensions.GetToken(_httpContextAccessor.HttpContext.User)}");
        request.AddJsonBody(body);
        return client.ExecuteAsync(request);

    }

    public Task<T> ProcessApiResponseAsync<T>(RestResponse response)
    {
        if (response.StatusCode== HttpStatusCode.OK)
        {
            try
            {
                var result = JsonSerializer.Deserialize<T>(response.Content);
                return Task.FromResult(result);
            }
            catch (Exception e )
            {

                Console.WriteLine("Exception : ",e.Message);
                return Task.FromResult(default(T));
            }
           
        }
        else
        {
            return Task.FromResult(default(T));
        }
        
    }

}
