using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whollet.ViewModel;
using Whollet.Views.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Whollet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnboardingPage : ContentPage
    {
        public OnboardingPage(OnboardingViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(false);
        }
    }
}