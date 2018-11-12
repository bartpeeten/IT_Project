using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KBVB.AR.Services
{
    public interface INavigationServiceWithInit : INavigationService
    {
        void Initialize(NavigationPage navigation);
    }
}
