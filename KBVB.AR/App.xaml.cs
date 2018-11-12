using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using KBVB.AR.Data;
using KBVB.AR.Services;
using KBVB.AR.ViewModels;
using KBVB.AR.Views;
using Xamarin.Forms;

namespace KBVB.AR
{
	public partial class App : Application
	{
		public App ()
		{
		    InitializeComponent();

		    var navigationService = new NavigationService();
            navigationService.Configure(ViewModelLocator.HomeView, typeof(HomeView));
            navigationService.Configure(ViewModelLocator.GalleryView, typeof(GalleryView));
            navigationService.Configure(ViewModelLocator.LoginView, typeof(LoginView));
            navigationService.Configure(ViewModelLocator.FacebookLoginView, typeof(FacebookLoginView));

            SimpleIoc.Default.Register<INavigationServiceWithInit>(() => navigationService);

            var userDataService = new UserDataServiceMocked();
            SimpleIoc.Default.Register<IUserDataService>(()=> userDataService);

            var playerDataService = new PlayerDataServiceMocked();
            SimpleIoc.Default.Register<IPlayerDataService>(() => playerDataService);

		    var httpClient = new HttpClient();
		    httpClient.DefaultRequestHeaders.Accept.Clear();
		    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		    SimpleIoc.Default.Register<HttpClient>(() => httpClient);

            var mainPage = new NavigationPage(new LoginView());

		    navigationService.Initialize(mainPage);

		    MainPage = mainPage;
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
