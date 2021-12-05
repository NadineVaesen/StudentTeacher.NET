using SchoolMomentsApp.Extensions;
using SchoolMomentsApp.Models;
using SchoolMomentsApp.Models.Repository;
using SchoolMomentsApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolMomentsApp.ViewModels
{
    public class StudentsOverviewViewModel : BaseViewModel
    {
        public ObservableCollection<Student> _students;
        private IStudentDataService _studentDataService;
        

        public ObservableCollection<Student> Students
        {
            get => _students;
            set
            {
                _students = value;
                OnPropertyChanged("Students");
            }
        }

        public StudentsOverviewViewModel(INavigationService navigationService, IStudentDataService studentDataService) : base (navigationService)
        {
            _studentDataService = studentDataService;

             
        }

        public override async Task  InitializeAsync(object data)
        {
            IsBusy = true;
            Console.WriteLine("in MomentOverviewViewModel before calling momentDataService");
            Students = (await _studentDataService.GetAllStudents()).ToObservableCollection();
            IsBusy = false;

        }
    }
}
