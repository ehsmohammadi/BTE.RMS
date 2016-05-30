using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BTE.RMS.Presentation.Web.ViewModel.Account
{
    public class RegisterViewModel
    {
        public long Id { get; set; }


        [Required(ErrorMessage = "نام کاربری را وارد نمایید")]
        [Display(Name = "نام کاربری")]
        [StringLength(100, ErrorMessage = "نام کاربری باید بیشتر از 6 کاراکتر باشد", MinimumLength = 6)]
        public string Username { get; set; }


        [Required(ErrorMessage = "رمز عبور را وارد نمایید")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        [StringLength(100, ErrorMessage = "رمز عبور باید بیشتر از 6 کاراکتر باشد", MinimumLength = 6)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        [Compare("Password", ErrorMessage = "با رمز عبور یکسان نمی باشد")]
        public string ConfirmPassword { get; set; }
    }


    public class LoginViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Username { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool RememberMe { get; set; }
    }
}