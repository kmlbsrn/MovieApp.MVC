using System.ComponentModel.DataAnnotations;

namespace MovieApp.MVC.Models.User
{
    public class AddUserDetailModel:IModel
    {

        //public int UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public IFormFile? ProfilePicture { get; set; }

        public string? Biography { get; set; }

        public bool? Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? Facebook { get; set; }

        public string? Twitter { get; set; }

        public string? Instagram { get; set; }

    }
}
