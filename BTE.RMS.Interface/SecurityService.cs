using System;
using System.Linq;
using System.Security.Claims;
using BTE.RMS.Interface.Contract.Facade;

namespace BTE.RMS.Interface
{
    public class SecurityService : ISecurityService
    {

        #region Fields

        #endregion

        #region Constructors


        #endregion

        #region Methods

        public string GetCurrentUserName()
        {
            string userName=String.Empty;
            try
            {
                 userName = ClaimsPrincipal.Current.Claims.Single(c => c.Type == "Name").Value;
            }
            catch (System.Exception)
            {

                userName = ClaimsPrincipal.Current.Identity.Name;
            }
            return userName;
        }

        #endregion

    }
}
