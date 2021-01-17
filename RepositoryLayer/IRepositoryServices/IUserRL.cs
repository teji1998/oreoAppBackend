using CommonLayer.Models;
using oreoApplicationCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRL
    {
        bool Register(UserRegistration register);
        UserRegistration1 login(UserLogin registration);
    }
}
