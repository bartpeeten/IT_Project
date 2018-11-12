using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KBVB.AR.Services
{
    public interface IShareService
    {
        void Share(string subject, string message, ImageSource imageSource);
    }
}
