using BusinessLayer.Interfaces;
using CommonLayer.Models;
using oreoApplicationCommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL :IUserBL
    {
        private readonly IUserRL userRL;

        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public bool userRegister(UserRegistration userRegistration)
        {
            try
            {
                return this.userRL.Register(userRegistration);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public UserRegistration1 Login(UserLogin user)
        {
            try
            {
                return this.userRL.login(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
