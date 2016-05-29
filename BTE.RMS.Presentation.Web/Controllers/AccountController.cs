using BTE.Presentation.Web;
using BTE.RMS.Interface.Contract.Model.Users;
using BTE.RMS.Presentation.Web.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BTE.RMS.Presentation.Web.Controllers
{
    public class AccountController : Controller
    {

        #region Fields
        private readonly string endpoint = "account/register";
        private readonly string loginEndpoint = "token";

        private readonly Uri apiUri = new Uri(RMSClientConfig.BaseApiAddress);
        #endregion

        #region Methods

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Username,Password,ConfirmPassword")] RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {

                var userDto = RegisterViewModelMapToUserDto(registerViewModel);
                HttpClientHelper.Post(apiUri, endpoint, userDto);


                return null;
            }
            return View(registerViewModel);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Username,Password,RememberMe")] LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {

                //var loginDto = new LoginDto { Grant_type = "password" ,UserName = loginViewModel.Username,Password = loginViewModel.Password};
                var res = HttpClientHelper.PostFormUrlEncoded<TokenResponse>(new Uri(RMSClientConfig.BaseApiSiteAddress),
                    loginEndpoint,
                    new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("username",loginViewModel.Username ),
                        new KeyValuePair<string, string>("password", loginViewModel.Password)
                    });
                FormsAuthentication.SetAuthCookie(res.access_token, true);
                return RedirectToAction("Index","Meetings");
            }
            return View(loginViewModel);
        } 
        #endregion


        #region Private methods
        private RegistrationDto RegisterViewModelMapToUserDto(RegisterViewModel registerViewModel)
        {
            var userDto = new RegistrationDto
            {
                UserName=registerViewModel.Username,
                Password=registerViewModel.Password,
                ConfirmPassword=registerViewModel.ConfirmPassword
            };
            return userDto;
        }

        //private UserDto LoginViewModelMapToUserDto(LoginViewModel loginViewModel)
        //{
        //    var userDto = new UserDto
        //    {
        //        UserName = loginViewModel.Username,
        //        Password = loginViewModel.Password,
        //        ConfirmPassword = loginViewModel.Password
        //    };
        //    return userDto;
        //}
        #endregion
    }
}