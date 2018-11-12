using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using KBVB.AR.Data;
using KBVB.AR.Messages;
using KBVB.AR.Models;
using KBVB.AR.Services;
using KBVB.AR.Validations;
using KBVB.AR.Views;
using Xamarin.Forms;

namespace KBVB.AR.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly INavigationServiceWithInit _navigationService;
        private readonly IUserDataService _userDataService;

        public ICommand SignInWithFacebookCommand { get; set; }
        public ICommand SignInWithTwitterCommand { get; set; }
        public ICommand SignInWithEmailCommand { get; set; }

        private ValidatableObject<string> _email;
        private ValidatableObject<string> _password;
        private ValidatableObject<User> _user;

        public ValidatableObject<string> Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                RaisePropertyChanged(() => Email);
            }
        }

        public ValidatableObject<string> Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public ValidatableObject<User> User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                RaisePropertyChanged(() => User);
            }
        }

        public LoginViewModel(INavigationServiceWithInit navigationService, IUserDataService userDataService)
        {
            _navigationService = navigationService;
            _userDataService = userDataService;

            SignInWithFacebookCommand = new RelayCommand(SignInWithFacebook);
            SignInWithTwitterCommand = new RelayCommand(SignInWithTwitter);
            SignInWithEmailCommand = new RelayCommand(SignInWithEmail);

            _email = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();
            _user = new ValidatableObject<User>();
            AddValidations();

        }

        private void SignInWithEmail()
        {
          /**  bool isValid = Validate();
            bool isAuthenticated = false;
            
            if (isValid)
            {
                _user.Value = new User
                {
                    Email = _email.Value,
                    Password = _password.Value
                };


                isAuthenticated = Authenticate();
            }

            if (isAuthenticated) NavigateToHome(); **/
            NavigateToHome();
        }

        private void NavigateToHome()
        {
            var mainPage = new NavigationPage(new HomeView());

            _navigationService.Initialize(mainPage);

            App.Current.MainPage = mainPage;
        }

        private void AddValidations()
        {
            _email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "An email is required." });
            _email.Validations.Add(new EmailFormatRule<string> { ValidationMessage = "Please enter your email in a valid format" });
            _email.Validations.Add(new RegisteredEmailRule<string>(_userDataService) { ValidationMessage = "Email not found, please register first" });

            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A password is required." });

            _user.Validations.Add(new CredidentialsMatchRule<User>(_userDataService) { ValidationMessage = "incorrect password" });
        }

        private bool Validate()
        {
            bool isValidEmail = ValidateEmail();
            bool isValidPassword = ValidatePassword();

            return isValidEmail && isValidPassword;
        }

        private bool ValidateEmail()
        {
            return _email.Validate();
        }

        private bool ValidatePassword()
        {
            return _password.Validate();
        }    
        
        private bool Authenticate()
        {
            return _user.Validate();
        }

        private void SignInWithFacebook()
        {
            _navigationService.NavigateTo(ViewModelLocator.FacebookLoginView);
        }

        private void SignInWithTwitter()
        {

        }

    }
}
