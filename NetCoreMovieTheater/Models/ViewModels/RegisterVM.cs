using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Models.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="Kullanıcı adı boş geçilemez")]
        [Display(Name ="Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email boş geçilemez")]
        [EmailAddress(ErrorMessage ="Lütfen Email formatında giriş yapın.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez")]
        [Display(Name ="Şifre")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre (Tekrar) boş geçilemez")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor")]
        [Display(Name = "Şifre (Tekrar)")]
        public string ConfirmPassword { get; set; }
    }
}
