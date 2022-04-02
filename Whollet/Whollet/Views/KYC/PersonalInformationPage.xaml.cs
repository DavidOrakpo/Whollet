using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whollet.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Whollet.Views.KYC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonalInformationPage : ContentPage
    {
        public PersonalInformationPage(PersonalInformationViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}