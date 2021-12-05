using SchoolMomentsApp.Bootstrap;
using SchoolMomentsApp.Models;
using SchoolMomentsApp.ViewModels;
using SchoolMomentsApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SchoolMomentsApp.Services
{
   
    public class NavigationService : INavigationService
    {
       

        private readonly ILoginDataService _loginDataService;
        private readonly Dictionary<Type, Type> _mappings;
        private object role;
     

        protected Application CurrentApplication => Application.Current;

        public NavigationService(ILoginDataService loginDataService)

        {
            _loginDataService = loginDataService;
            _mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
 
        }

        public async Task InitializeAsync()
        { 
            //check if user is admin, teacher or admin and then nav to right page
            role = _loginDataService.AuthenticateUser();
            

            if (role is Teacher)
            {
                await NavigateToAsync<MomentOverviewViewModel>();

            } else if (role is Student)
            {
                await NavigateToAsync<StudentMainPageViewModel>();
            } 
            else if (role is Administrator)
            {
                await NavigateToAsync<MomentDetailViewModel>();
            } 
            else
            {
                await NavigateToAsync<LoginViewModel>();
            }
            
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return InternalNavigateToAsync(viewModelType, null);
        }

        public async Task ClearBackStack()
        {
            await CurrentApplication.MainPage.Navigation.PopToRootAsync();
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }

        public async Task NavigateBackAsync()
        {
            //here I need to see who logs in and send them to the correct page

            if (CurrentApplication.MainPage is MomentOverviewView mainPage)
            {
                await mainPage.Navigation.PopAsync();
            }
            else if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        public virtual Task RemoveLastFromBackStackAsync()
        {
            if (CurrentApplication.MainPage is MomentOverviewView mainPage)
            {
                mainPage.Navigation.RemovePage(
                    mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        public async Task PopToRootAsync()
        {
            if (CurrentApplication.MainPage is MomentOverviewView mainPage)
            {
                await mainPage.Navigation.PopToRootAsync();
            }
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            var page = CreatePage(viewModelType, parameter);

            if (page is MomentOverviewView || page is LoginView || page is StudentMainPageView)
            {
                CurrentApplication.MainPage = page;
            }
            else if (page is LoginView)
            {
                CurrentApplication.MainPage = page;
            } else if (page is StudentMainPageView)
            {
                CurrentApplication.MainPage = page;
            }
            else if (CurrentApplication.MainPage is MomentOverviewView)
            {
                var mainPage = CurrentApplication.MainPage as MomentOverviewView;
                
            }

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            var index = viewModelType.Name.LastIndexOf("Model", StringComparison.Ordinal);
            var pageTypeName = viewModelType.Name.Remove(index, 5);

            var pageType = viewModelType.Assembly.GetTypes().FirstOrDefault(t => t.Name == pageTypeName);
            if (pageType == null)
            {
                throw new InvalidOperationException($"No view type found for ${viewModelType}.");
            }

            return pageType;
        }

        protected Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            BaseViewModel viewModel = AppContainer.Resolve(viewModelType) as BaseViewModel;
            page.BindingContext = viewModel;

            return page;
        }

        private void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(LoginViewModel), typeof(LoginView));
            _mappings.Add(typeof(MomentDetailViewModel), typeof(MomentDetailView));
            _mappings.Add(typeof(MomentOverviewViewModel), typeof(MomentOverviewView));
            _mappings.Add(typeof(RegisterStudentForMomentViewModel), typeof(RegisterStudentForMomentView));
            _mappings.Add(typeof(StudentMainPageViewModel), typeof(StudentMainPageView));
            _mappings.Add(typeof(StudentsOverviewViewModel), typeof(StudentsOverviewView));
        }
    }
}
