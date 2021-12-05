using SchoolMomentsApp.Models;
using SchoolMomentsApp.Services;
using SchoolMomentsApp.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SchoolMomentsApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string _personelNumber;
        public string _password;
        public string _errorMessage;
        string PersonelNumber
        {
            get => _personelNumber;
            set
            {
                if (_personelNumber != value)
                {
                    OnPropertyChanged("PersonelNumber");
                }
            }
        }
        string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    OnPropertyChanged("Password");
                }
            }
        }

        private ILoginDataService _loginDataService;

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage != value)
                {
                    OnPropertyChanged("errorMessage");
                }
            }
        }


        public LoginViewModel(INavigationService navigationService, ILoginDataService loginDataService) : base(navigationService)
        {
            _loginDataService = loginDataService;

        }

        public ICommand Login => new Command(OnLogin);


        private void OnLogin()
        {
            Console.WriteLine("in OnLogin");
            //if user is known => Determine type of user => navigate to the right page
            object role = _loginDataService.AuthenticateUser();

            if (role is Student)
            {
                _navigationService.NavigateToAsync<StudentMainPageViewModel>();
            }
            else if (role is Teacher)
            {
                _navigationService.NavigateToAsync<MomentOverviewViewModel>();
            }
            else if (role is Administrator)
            {
                //nog niks
            }
            else
            {
                _navigationService.NavigateBackAsync();
            }

        }

        public override Task InitializeAsync(object parameter)
        {
            
            if (parameter is string)
            {
                 ErrorMessage = "This user/password is incorrect. Please enter the correct credentials";

            }
            return Task.Run(null);
            


        }


    }
}
