﻿using oreoApplicationCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace oreoApplicationBusinessLayer.IBusinessService
{
    public interface IAdminBL
    {
        bool AdminRegister(AdminRegistration registration);
        AdminResponse AdminLogin(AdminLogin adminLogin);
    }
}
