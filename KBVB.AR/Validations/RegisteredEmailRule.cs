using GalaSoft.MvvmLight.Ioc;
using KBVB.AR.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBVB.AR.Validations
{
    public class RegisteredEmailRule<T> : IValidationRule<T>
    {
        private IUserDataService _userDataService;

        public RegisteredEmailRule(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            var email = value as string;
            return (_userDataService.GetUserByEmail(email)!=null);
        }
    }
}
