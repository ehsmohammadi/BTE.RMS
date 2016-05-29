using BTE.Presentation.Web;
using BTE.RMS.Interface.Contract.Model.Users;
using BTE.RMS.Presentation.Web.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

                //var userDto = LoginViewModelMapToUserDto(loginViewModel);
                 var res=HttpClientHelper.Post<string, string>(new Uri(RMSClientConfig.BaseApiSiteAddress), loginEndpoint, "grant_type = password & username ="+loginViewModel.Username+" & password ="+loginViewModel.Password);
                //login
                return null;
            }
            return View(loginViewModel);
        } 
        #endregion


        #region Private methods
        private UserDto RegisterViewModelMapToUserDto(RegisterViewModel registerViewModel)
        {
            var userDto = new UserDto
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