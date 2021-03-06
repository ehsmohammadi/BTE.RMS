﻿using System.Threading.Tasks;
using System.Web.Http;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.Model;
using BTE.RMS.Interface.Contract.Model.Users;
using Microsoft.AspNet.Identity;

namespace BTE.RMS.Interface.WebApi.Host.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly IUserFacadeService userFacadeService;
        private AuthRepository repo = null;

        public AccountController(IUserFacadeService userFacadeService)
        {
            this.userFacadeService = userFacadeService;
            repo = new AuthRepository();
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegistrationDto userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await repo.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            userFacadeService.Create(userModel);

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
