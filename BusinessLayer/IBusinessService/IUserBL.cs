using CommonLayer.Models;
using oreoApplicationCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        bool userRegister(UserRegistration userRegistration);
        UserResponse Login(UserLogin registration);

    }
}
