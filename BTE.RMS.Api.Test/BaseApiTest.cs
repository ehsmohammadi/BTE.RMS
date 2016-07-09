using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract.Model.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BTE.RMS.Api.Test
{
    [TestClass]
    public class BaseApiTest
    {
        protected string AuthToken=string.Empty;
        protected Uri webApiUrl { get { return new Uri(string.Format("{0}api/",webApiSiteAddress)); } }

        private string webApiSiteAddress { get { return "http://localhost:3030/"; } }

        protected BaseApiTest()
        {

        }

        //Use TestInitialize to run code before running each test 
        [TestInitialize]
        public void MyTestInitialize()
        {
            var res = TestHttpClientHelper.PostFormUrlEncoded<TokenResponse>(new Uri(webApiSiteAddress), "token",
                                new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("username","EHSANLAPEhsan" ),
                        new KeyValuePair<string, string>("password", "123456")
                    });
            AuthToken = res.access_token;
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void MyTestCleanup()
        {

        }
    }
}
