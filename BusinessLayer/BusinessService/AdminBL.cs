using oreoApplicationBusinessLayer.IBusinessService;
using oreoApplicationCommonLayer.Models;
using oreoApplicationRepositoryLayer.IRepositoryServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace oreoApplicationBusinessLayer.BusinessService
{
    public class AdminBL:IAdminBL
    {
        private readonly IAdminRL adminRL;

        public AdminBL(IAdminRL adminRL)
        {
            this.adminRL = adminRL;
        }

        public bool AdminRegister(AdminRegistration adminRegistration)
        {
            try
            {
                return this.adminRL.AdminRegister(adminRegistration);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public AdminRegistration1 AdminLogin(AdminLogin adminLogin)
        {
            try
            {
                return this.adminRL.loginAdmin(adminLogin);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
