using System;
using System.Collections.Generic;
using System.Text;
using KBVB.AR.Models;

namespace KBVB.AR.Data
{
    public class UserDataServiceMocked : IUserDataService
    {
        private List<User> fakeUsers;

        public UserDataServiceMocked()
        {
            fakeUsers = MockDataBuilder.GetAllUsers();
        }

        public User GetUserByEmail(string email)
        {
            User user = null;

            user = fakeUsers.Find(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            return user;
        }
    }
}
