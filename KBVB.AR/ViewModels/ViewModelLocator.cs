using System;
using System.Collections.Generic;
using System.Text;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace KBVB.AR.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {

            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<GalleryViewModel>();
            SimpleIoc.Default.Register<PlayerInfoViewModel>();
            SimpleIoc.Default.Register<FacebookLoginViewModel>();
        }

        public LoginViewModel LoginViewModel
        {
            get => SimpleIoc.Default.GetInstance<LoginViewModel>();
        }

        public GalleryViewModel GalleryViewModel
        {
            get => SimpleIoc.Default.GetInstance<GalleryViewModel>();
        }

        public HomeViewModel HomeViewModel 
        {
            get => SimpleIoc.Default.GetInstance<HomeViewModel>();
        }

        public PlayerInfoViewModel PlayerInfoViewModel
        {
            get => SimpleIoc.Default.GetInstance<PlayerInfoViewModel>();
        }

        public FacebookLoginViewModel FacebookLoginViewModel
        {
            get => SimpleIoc.Default.GetInstance<FacebookLoginViewModel>();
        }

        public const string LoginView = "LoginView";
        public const string HomeView = "HomeView";
        public const string GalleryView = "GalleryView";
        public const string PlayerInfoView = "PlayerInfoView";
        public const string FacebookLoginView = "FacebookLoginView";
    }
}
