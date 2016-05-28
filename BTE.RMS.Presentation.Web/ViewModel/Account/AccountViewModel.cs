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
        public string Username { get; set; }


        [Required(ErrorMessage="رمز عبور را وارد نمایید")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        [Compare("Password", ErrorMessage = "با رمز عبور یکسان نمی باشد")]
        public string ConfirmPassword { get; set; }
    }
}