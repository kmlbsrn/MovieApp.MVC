using System.ComponentModel.DataAnnotations;

namespace MovieApp.MVC.Models
{
    public class RegisterViewModel
    {

        [Display(Name ="UserName")]
        [Required(ErrorMessage = "Kullanıcı adı kısmı boş olamaz")]
        public string UserName { get; set; }

        [Display(Name ="Email")]
        [Required(ErrorMessage = "Email kısmı boş olamaz")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
        public string Email { get; set; }

        [Display(Name ="Password")]
        [Required(ErrorMessage = "Şifre kısmı boş olamaz")]
        [MinLength(4, ErrorMessage = "Şifre en az 4 karakter olmalıdır")]
        public string Password { get; set; }

        [Display(Name ="Confirm Password")]
        [Required(ErrorMessage = "Şifre tekrarı kısmı boş olamaz")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }



    }
}
