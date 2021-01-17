using oreoApplicationCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace oreoApplicationRepositoryLayer.IRepositoryServices
{
    public interface IAdminRL
    {
        bool AdminRegister(AdminRegistration register);
        AdminRegistration1 loginAdmin(AdminLogin registration);
    } 
}
