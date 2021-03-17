using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Kullanıcı adı boş geçilemez!")]
        [Display(Name ="Kullanıcı Adı")]
        public string  UserName { get; set; }
        [Required(ErrorMessage ="Şifre boş geçilemez")]
        [Display(Name ="Şifre")]
        public string Password { get; set; }
        public bool IsPersistant { get; set; }
    }
}
