using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using KBVB.AR.Messages;
using KBVB.AR.Services;
using KBVB.AR.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace KBVB.AR.ViewModels
{
    public class FacebookLoginViewModel
    {
        private INavigationServiceWithInit _navigationService;

        private string ClientId = "834484526743405";

        public FacebookLoginViewModel(INavigationServiceWithInit navigationService)
        {
            _navigationService = navigationService;

            Messenger.Default.Register<CurrentPageMessage>
                (
                    this, (message) => SetContent(message)
                );
        }

        private void SetContent(CurrentPageMessage message)
        {
            var apiRequest =
                "https://www.facebook.com/v3.0/dialog/oauth?client_id="
                + ClientId
                + "&display=popup&response_type=token&redirect_uri=https://www.facebook.com/connect/login_success.html";

            var webView = new WebView
            {
                Source = apiRequest,
                HeightRequest = 1
            };

            webView.Navigated += WebViewOnNavigated;

            message.CurrentPage.Content = webView;
        }

        private void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {
            var accessToken = ExtractAccessTokenFromUrl(e.Url);

            if (accessToken != "")
            {
                var mainPage = new NavigationPage(new HomeView());

                _navigationService.Initialize(mainPage);

                App.Current.MainPage = mainPage;

            }

        }

        private string ExtractAccessTokenFromUrl(string url)
        {
            if (url.Contains("access_token") && url.Contains("&expires_in="))
            {
                var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

                var accessToken = at.Remove(at.IndexOf("&expires_in="));

                return accessToken;
            }

            return string.Empty;

        }
    }
}


        
