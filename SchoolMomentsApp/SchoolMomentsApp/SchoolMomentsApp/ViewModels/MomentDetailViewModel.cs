using SchoolMomentsApp.Models;
using SchoolMomentsApp.Models.Repository;
using SchoolMomentsApp.Services;
using SchoolMomentsApp.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SchoolMomentsApp.ViewModels
{
    public class MomentDetailViewModel : BaseViewModel
    {
        private Moment _selectedMoment;

        private IMomentDataService _momentDataService;
       

        public Moment SelectedMoment
        {
            get => _selectedMoment; 
            set
            {
                _selectedMoment = value;
                Console.WriteLine("MOMENT DETAILVIEWMODEL: " + _selectedMoment.Name);
                OnPropertyChanged("SelectedMoment");
            }
        }

        public MomentDetailViewModel(INavigationService navigationService, IMomentDataService momentDataService) : base(navigationService)
        {
            //instantiate to make sure it's created upon the creation of the viewmodel
            _momentDataService = momentDataService;
            //SelectedMoment = new Moment();

            //listening if moment changes
            MessagingCenter.Subscribe<MomentDetailViewModel, Moment>
                (this, MessageNames.MomentChangedMessage, OnMomentChanged);

        }

        //public ICommand LoadAttendedStudents => new Command(OnLoadAttendedStudents);
        //public ICommand LoadRequestedStudents => new Command(OnLoadRequestedStudents);
        //public ICommand LoadAbsentStudents => new Command(OnLoadAbsentStudents);
        //public ICommand RegisterStudent => new Command(OnRegisterStudent);

        private async void OnMomentChanged(MomentDetailViewModel sender, Moment moment)
        {
            SelectedMoment = await _momentDataService.GetMomentAsync(moment.MomentId);
        }

        //private void OnLoadAttendedStudents(object obj)
        //{
        //    _navigationService.NavigateToAsync<StudentsOverviewViewModel>(SelectedMoment);
        //}

        //private void OnLoadRequestedStudents(object obj)
        //{
        //    _navigationService.NavigateToAsync<StudentsOverviewViewModel>(SelectedMoment);
        //}

        //private void OnLoadAbsentStudents(object obj)
        //{
        //    _navigationService.NavigateToAsync<StudentsOverviewViewModel>(SelectedMoment);
        //}

       
        //private void OnRegisterStudent(object obj)
        //{
        //    _navigationService.NavigateToAsync<RegisterStudentForMomentViewModel>(SelectedMoment);
        //}


        public override Task InitializeAsync(object parameter)
        {
            Console.WriteLine("MOMENTDETAILVIEWMODEL: in InitializeAsync");
            //Console.WriteLine("parameter: " + (Moment) parameter);
            SelectedMoment = (Moment)parameter;
            Console.WriteLine("SelectedMoment: " + SelectedMoment.Name);
            return Task.Run(null);

        }
    }
    
}
