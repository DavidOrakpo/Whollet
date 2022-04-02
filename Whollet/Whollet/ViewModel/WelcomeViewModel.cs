using System;
using System.Collections.Generic;
using System.Text;
using Whollet.Views.Login;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    public class WelcomeViewModel : BaseViewModel
    {
        public WelcomeViewModel()
        {

        }

        public Command GotoLogin => new Command(() =>
        {

            GoToPageAsync(Startup.Resolve<LoginPage>());

        });

        public Command GotoSignup => new Command(() =>
        {

            GoToPageAsync(Startup.Resolve<SignupView>());


        });
    }
}
