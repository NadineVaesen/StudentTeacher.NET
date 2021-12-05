
using SchoolMomentsApp.Extensions;
using SchoolMomentsApp.Models;
using SchoolMomentsApp.Services;
using SchoolMomentsApp.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SchoolMomentsApp.ViewModels
{
    public class MomentOverviewViewModel : BaseViewModel
    {
        
        private ObservableCollection<Moment> _moments;
        public ICommand MomentSelectedCommand { get; }
        public IMomentDataService _momentDataService;
        
        public ObservableCollection<Moment> Moments
        {
            get => _moments;
            set
            {
                _moments = value;
                OnPropertyChanged();
            }
        }

        public MomentOverviewViewModel(IMomentDataService momentDataService, INavigationService navigationService) : base(navigationService)
        {
            _momentDataService = momentDataService;
      
            MomentSelectedCommand = new Command<Moment>(OnMomentSelection);
 
        }

        public override async Task InitializeAsync(object data)
        {
            IsBusy = true;
            Console.WriteLine("in MomentOverviewViewModel before calling momentDataService");
            Moments = (await _momentDataService.GetAllMomentsAsync()).ToObservableCollection();
            IsBusy = false;
            
        }


        private void OnMomentSelection(Moment moment)
        {
            Console.WriteLine("MOMENTOVERVIEWVIEWMODEL : in OnMomentSelection");
            Console.WriteLine(moment.Name);
            _navigationService.NavigateToAsync<MomentDetailViewModel>(moment);
            
        }
    }
}
