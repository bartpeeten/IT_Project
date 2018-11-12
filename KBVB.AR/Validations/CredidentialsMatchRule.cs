using KBVB.AR.Data;
using KBVB.AR.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBVB.AR.Validations
{
    public class CredidentialsMatchRule<T> : IValidationRule<T>
    {
        private IUserDataService _userDataService;

        public CredidentialsMatchRule(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            var user = value as User;
            User userInMemory = _userDataService.GetUserByEmail(user.Email);
            return (userInMemory.Password.Equals(user.Password));
        }
    }
}
