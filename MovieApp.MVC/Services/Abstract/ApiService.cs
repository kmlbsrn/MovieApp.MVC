using RestSharp;

namespace MovieApp.MVC.Services.Abstract
{
    public interface ApiService
    {

        Task<RestResponse> ExecuteMovieApiRequestAsync(string resource, Method method);
        Task<RestResponse> ExecuteMovieApiRequestAsync(string resource, Method method, object body);
        Task<T> ProcessApiResponseAsync<T>(RestResponse response);
    }
}
