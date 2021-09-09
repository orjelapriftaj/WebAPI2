using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IUserInfo
    {
        UserInfo Authenticate(string username, string password);
    }
}
