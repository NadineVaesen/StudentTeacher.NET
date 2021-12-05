
using SchoolMomentsApp.Bootstrap;
using SchoolMomentsApp.Services;
using SchoolMomentsApp.Utility;
using SchoolMomentsApp.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SchoolMomentsApp
{

    
    public partial class App : Application
    {

        public App()
        {

            InitializeComponent();

            InitializeApp();

            InitializeNavigation();

            MainPage = new NavigationPage(new LoginView());
        }

        private void InitializeApp()
        {
            AppContainer.RegisterDependencies();
        }

        private async Task InitializeNavigation()
        {
            var navigationService = AppContainer.Resolve<INavigationService>();
            await navigationService.InitializeAsync();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
