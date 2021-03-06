﻿using System;
using System.Security.Authentication;

namespace BTE.RMS.Model.Users
{
    public class User
    {
        #region Properties
        public long Id { set; get; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        #endregion

        #region Constructors
        protected User()
        {

        }

        public User(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("User:userName can not be null", "userName");
            UserName = userName;
        } 
        #endregion

        public void AllowToDoAction(User actionOwner)
        {
            if(actionOwner.UserName!=this.UserName)
                throw new Exception("User Cant do the action");

            
        }
    }
}
