using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whollet.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Whollet.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomeView : ContentPage
    {
        public WelcomeView(WelcomeViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
            if (ShouldShowOnboarding())
            {
                var onboard = Startup.Resolve<OnboardingPage>();
                Navigation.PushModalAsync(onboard, false);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(Startup.Resolve<SignupView>());
        }

        private bool ShouldShowOnboarding()
        {
            return true;
        }
    }
}