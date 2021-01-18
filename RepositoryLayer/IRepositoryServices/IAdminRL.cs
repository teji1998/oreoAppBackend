using oreoApplicationCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace oreoApplicationRepositoryLayer.IRepositoryServices
{
    public interface IAdminRL
    {
        bool AdminRegister(AdminRegistration register);
        AdminResponse loginAdmin(AdminLogin registration);
    } 
}
