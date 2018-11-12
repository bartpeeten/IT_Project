using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace KBVB.AR.Validations
{
    public class EmailFormatRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(str);
            return match.Success;
        }
    }
}
