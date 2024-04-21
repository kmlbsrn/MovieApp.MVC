namespace MovieApp.MVC.Models.User
{
    public class AddUserDetailReq
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public string? Biography { get; set; }

        public bool? Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? Facebook { get; set; }

        public string? Twitter { get; set; }

        public string? Instagram { get; set; }
    }
}
