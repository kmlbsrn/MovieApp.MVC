namespace MovieApp.MVC.Models.Review
{
    public class AddReviewModel:IModel
    {
        public AddReviewModel(int id)
        {
            
            MovieId = id;
        }

        public AddReviewModel()
        {
            
        }

        public int MovieId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
