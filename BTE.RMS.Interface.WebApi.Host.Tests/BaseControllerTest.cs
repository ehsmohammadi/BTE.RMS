using System.Security.Claims;
using System.Transactions;
using BTE.Core;
using BTE.RMS.Interface.Contract.Model.Users;
using BTE.RMS.Interface.WebApi.Host.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BTE.RMS.Interface.WebApi.Host.Tests
{
    [TestClass]
    public class BaseControllerTest
    {
        public TestContext TestContext { get; set; }

        private TransactionScope transactionScope;
        protected BaseControllerTest()
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.Execute();
        }

        //Use TestInitialize to run code before running each test 
        [TestInitialize]
        public void MyTestInitialize()
        {
            transactionScope = new TransactionScope();
            var acountService = ServiceLocator.Current.GetInstance<AccountController>();
            var res =
                acountService.Register(new RegistrationDto
                {
                    UserName = ClaimsPrincipal.Current.Identity.Name,
                    Password = "123456",
                    ConfirmPassword = "123456"
                }).Result;

        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void MyTestCleanup()
        {
            transactionScope.Dispose();
        }
    }
}
