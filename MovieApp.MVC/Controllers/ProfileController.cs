using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.MVC.Models.User;
using MovieApp.MVC.Services.Abstract;

namespace MovieApp.MVC.Controllers
{
    public class ProfileController : Controller
    {

        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        public ProfileController(IUserService userService, IWebHostEnvironment environment,IMapper mapper)
        {
            _userService = userService;
            _environment = environment;
            _mapper = mapper;
        }

        [HttpGet("myProfile")]
        [Authorize(Roles ="User,Admin")]
        public IActionResult Index()
        {

            var userInfo= _userService.GetUserInfo();

            return View("Index", userInfo.Result);
            
           



        }

        [HttpGet("userProfile")]

        public IActionResult OtherProfile(int userId)
        {
           var viewModel = _userService.GetProfileUserInfoById(userId).Result;


            
            return View("OtherUserProfile",viewModel);
            
        }

        // add User details
        [Authorize(Roles ="User,Admin")]
        public IActionResult Detail()
        {

            return View();
        }

        [HttpPost]
        [Authorize(Roles ="User,Admin")]
        public IActionResult Save(AddUserDetailModel formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Detail", formData);
            }

            var newFileName = "";

            if (formData.ProfilePicture is not null) // dosya yüklenmek isteniyorsa
            {
                var allowedFileTypes = new string[] { "image/jpeg", "image/jpg", "image/png", "image/jfif", "image/avif" };

                var allowedFileExtensions = new string[] { ".jpg", ".jpeg", ".png", ".jfif", ".avif" };


                var fileContentType = formData.ProfilePicture.ContentType;
                // dosyanın içeriği

                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(formData.ProfilePicture.FileName);
                // dosyanın uzantısız ismi

                var fileExtension = Path.GetExtension(formData.ProfilePicture.FileName);
                // dosyanın uzantaısı

                if (!allowedFileTypes.Contains(fileContentType) ||
                    !allowedFileExtensions.Contains(fileExtension))
                {

                    ViewBag.ImageErrorMessage = "Yüklediğiniz dosya" + fileExtension + " uzantısında. Sisteme yalnızca .jpg .pjeg .png .jfif .avif formatında dosyalar yüklenebilir.";
                    return View("Form", formData);
                }

                newFileName = fileNameWithoutExtension + "-" + Guid.NewGuid() + fileExtension;

                // Aynı isimde iki dosya yüklediğimizde hata almamak için her dosyayı birbiriyle asla eşleşmeyecek şekilde isimlendiriyorum. Guid : unique bir string verir.

                // Bu aşamadan sonra görseli yükleyeceğim adresi ayarlıyorum.

                var folderPath = Path.Combine("image", "userProfile");
                // image/userProfile

                var wwwrootFolderPath = Path.Combine(_environment.WebRootPath, folderPath);
                // .../wwwroot/image/userProfile

                var filePath = Path.Combine(wwwrootFolderPath, newFileName);
                // .../wwwroot/image/userProfile/urunGorsel-123123adwaw13daw.jpg

                Directory.CreateDirectory(wwwrootFolderPath); // wwwroot/image/userProfile klasörü yoksa oluştur.

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formData.ProfilePicture.CopyTo(fileStream);
                    // asıl dosya kopyalamasının yapıldığı kısım.
                }
                // using içerisinde new'lenen fileStream nesnesi scope boyunca yaşar, scope bitiminde silinir.


            }


            var model =_mapper.Map<AddUserDetailReq>(formData);

            model.ProfilePictureUrl = newFileName;

            var response = _userService.AddUserDetail(model);

            

            if (response.Result.Success)
            {
                TempData["SuccessMessage"] = "Profil bilgileriniz başarıyla güncellendi.";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", response.Result.Message);
                return View("Detail", formData);
            }
        }


    }
}
