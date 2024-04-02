
using MovieApp.MVC.Models.Review;

namespace MovieApp.MVC.Services.Abstract
{
    public interface IReviewService
    {
        Task<MovieApp.MVC.Models.Result.IResult> AddReview(AddReviewModel addReviewModel);

        Task<List<ReviewListModel>> GetReviewsByMovieId(int movieId);


    }
}
