using System;
using System.Collections.Generic;
using System.Text;
using Whollet.Views.Login;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    internal class WelcomeViewModel : BaseViewModel
    {
        public WelcomeViewModel()
        {

        }

        public Command GotoLogin => new Command(() =>
        {

            Application.Current.MainPage.Navigation.PushAsync(new LoginPage());

        });

        public Command GotoSignup => new Command(() =>
        {

            Application.Current.MainPage.Navigation.PushAsync(new SignupView());


        });
    }
}
