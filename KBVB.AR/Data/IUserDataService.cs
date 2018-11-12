using KBVB.AR.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBVB.AR.Data
{
    public interface IUserDataService
    {
        User GetUserByEmail(string email);
    }
}
