using SchoolMomentsApp.Utility;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SchoolMomentsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentsOverviewView : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public StudentsOverviewView()
        {
            InitializeComponent();
  
        }

    }
}
