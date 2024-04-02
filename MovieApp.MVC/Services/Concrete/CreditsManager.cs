using MovieApp.MVC.Models.Credits;
using MovieApp.MVC.Services.Abstract;
using RestSharp;

namespace MovieApp.MVC.Services.Concrete
{
    public class CreditsManager : ICreditsService
    {
        private readonly ApiService _apiService;

        public CreditsManager(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<ActorDetailModel> GetActorDetail(int id)
        {
            var response = await _apiService.ExecuteMovieApiRequestAsync($"Credits/Detail?actorId={id}", Method.Get);
            return await _apiService.ProcessApiResponseAsync<ActorDetailModel>(response);
        }

        public async Task<CreditsListViewModel> GetCreditsByMovieId(int id)
        {
            var respomse= await _apiService.ExecuteMovieApiRequestAsync($"Credits/getCreditsbyMovieId?movieId={id}", Method.Get); 
            return await _apiService.ProcessApiResponseAsync<CreditsListViewModel>(respomse);

        }

        public async Task<FilmographyModel> GetFilmography(int id)
        {
            
            var response = await _apiService.ExecuteMovieApiRequestAsync($"Credits/Filmography?actorId={id}", Method.Get);
            return  await _apiService.ProcessApiResponseAsync<FilmographyModel>(response);
        }
    }
}
