using AutoMapper;
using MovieApp.MVC.Models.User;

namespace MovieApp.MVC.MappingProfile
{
    public class UserMappingProfile:Profile
    {

        public UserMappingProfile()
        {
            // AddUserDetailModel to AddUserDetailReq
            CreateMap<AddUserDetailModel, AddUserDetailReq>();
        }
    }
}
