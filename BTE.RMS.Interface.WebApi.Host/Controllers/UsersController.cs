using System.Collections.Generic;
using System.Web.Http;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.Model.Users;

namespace BTE.RMS.Interface.WebApi.Host.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {
        //#region Fields
        //private readonly IUserFacadeService userService;       
        //#endregion

        //#region Costructors

        //public UsersController(IUserFacadeService userService)
        //{
        //    this.userService = userService;
        //}

        //#endregion

        //#region Normal Methods
        //public void Post(UserDto model)
        //{
        //    userService.Create(model,AppType.WebApp);
        //}

        //public IList<UserDto> GetAll()
        //{
        //    return userService.GetAll();
        //}
        //#endregion

        //#region SyncMethods
        //[HttpGet]
        //public IEnumerable<UserDto> GetAll(int deviceType)
        //{
        //    var tasks = userService.GetAllUnSync(deviceType);
        //    return tasks;
        //}

        //[HttpPost]
        //public IHttpActionResult PostTasks(UserSyncRequest syncReuest)
        //{
        //    userService.Sync(syncReuest);
        //    return Ok();
        //} 
        //#endregion
    }
}
