using MovieApp.MVC.Models.Credits;

namespace MovieApp.MVC.Services.Abstract
{
    public interface ICreditsService
    {

        Task<CreditsListViewModel> GetCreditsByMovieId(int id);


        Task<ActorDetailModel> GetActorDetail(int id);


        Task<FilmographyModel> GetFilmography(int id);

    }
}
