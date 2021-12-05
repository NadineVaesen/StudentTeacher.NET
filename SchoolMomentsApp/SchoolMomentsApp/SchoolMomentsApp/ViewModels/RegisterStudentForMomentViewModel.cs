using SchoolMomentsApp.Models;
using SchoolMomentsApp.Services;
using SchoolMomentsApp.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SchoolMomentsApp.ViewModels
{
    public class RegisterStudentForMomentViewModel : BaseViewModel
    {
        private string studentnumber;
        private ICommand ConfirmStudentPresence;

        public RegisterStudentForMomentViewModel(INavigationService navigationService) : base(navigationService)
        {
            ConfirmStudentPresence = new Command<Moment>(OnConfirmStudent);
        }

        private void OnConfirmStudent(Moment moment)
        {
            //let the moment know that it's lists of students changed
            MessagingCenter.Send(this, MessageNames.MomentChangedMessage, moment);
       
            _navigationService.NavigateToAsync<MomentOverviewViewModel>();
        }

        //If I received a studentnumber => check if the student is in the list of requested studends
        //YES? show StudentName to confirm it's presence
        //NO? show Message => student is not supposed to be in this lesson


    }
}
